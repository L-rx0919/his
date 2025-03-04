using Lazy.Captcha.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using HIS.Utility;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DocumentFormat.OpenXml.EMMA;
using Polly.Caching;
using System.IO;
namespace HIS.SystemServices
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class SystemUserServices : ApplicationService, ISystemUserServices
    {
        private readonly ICaptcha captcha;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration configuration;
        private readonly IRepository<SystemUser> repositoryUser;
        private readonly IRepository<SystemDept> repositoryDept;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="captcha"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="configuration"></param>
        /// <param name="repository"></param>
        /// <param name="repositoryUser"></param>
        public SystemUserServices(ICaptcha captcha, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IRepository<SystemUser> repository, IRepository<SystemDept> repositoryUser)
        {
            this.captcha = captcha;
            this.httpContextAccessor = httpContextAccessor;
            this.configuration = configuration;
            this.repositoryUser = repository;
            this.repositoryDept = repositoryUser;
        }





        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        [HttpPost("/init")]
        public async Task<APIResult<int>> InitDataAsync()
        {
            try
            {
                var sysDept = new SystemDept()
                {
                    Code = "IoT",
                    Name = "物联网学院",
                    ParentId = Guid.Empty,
                    Sort = 0,
                    Status = Status.Enabled,
                    TreePath = Guid.Empty.ToString()
                };
                await repositoryDept.InsertAsync(sysDept);


                SystemUser sysUser = new SystemUser
                {
                    Avatar = "https://c-ssl.duitang.com/uploads/blog/202207/18/20220718021545_9db54.jpeg",
                    DeptId = sysDept.Id,
                    Mobile = "13693288263",
                    Nickname = "Feeling",
                    Password = "admin123".ComputeSha256Hash(),
                    Status = Status.Enabled,
                    Username = "admin",
                    Email = "superfeeling@126.com"
                };

                await repositoryUser.InsertAsync(sysUser);

                return new APIResult<int>
                {
                    Code = CodeEnum.success,
                    Message = "初始化数据成功",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/auth/captcha")]

        public APIResult<CaptchaDto> Captcha()
        {
            string guid = $"captcha:{Guid.NewGuid().ToString("N")}";
            // 有多处验证码且过期时间不一样，可传第二个参数覆盖默认配置。
            var info = captcha.Generate(guid, 120);
            httpContextAccessor.HttpContext.Response.Cookies.Append("ValidateCode", guid);

            var stream = new System.IO.MemoryStream(info.Bytes);
            return new APIResult<CaptchaDto>
            {
                Code = CodeEnum.success,
                Message = string.Empty,
                Data = new CaptchaDto
                {
                    captchaBase64 = $"data:image/gif;base64,{Convert.ToBase64String(stream.ToArray())}",
                    captchaKey = guid
                }
            };
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/auth/login")]
       
        public async Task<APIResult<LoginResultDto>> LoginAsync([FromForm] LoginDto loginDto)
        {
            try
            {
                var Port = new Uri(httpContextAccessor.HttpContext.Request.Headers["Referer"]).Port;
                if (!captcha.Validate(httpContextAccessor.HttpContext.Request.Cookies["ValidateCode"], loginDto.CaptchaCode) && Port == 3000)
                {
                    return new APIResult<LoginResultDto> { Code = CodeEnum.error, Message = "验证码不正确" };
                }
                var admin = await repositoryUser.FindAsync(m => m.Username == loginDto.Username);
                if (admin == null)
                {
                    return new APIResult<LoginResultDto> { Code = CodeEnum.error, Message = "用户未找到" };
                }
                else
                {
                    if (admin.Password != loginDto.Password.ComputeSha256Hash())
                    {
                        return new APIResult<LoginResultDto> { Code = CodeEnum.error, Message = "密码不正确" };
                    }
                    else
                    {
                        return new APIResult<LoginResultDto>
                        {
                            Code = CodeEnum.success,
                            Data = GenerateToken(admin)
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new APIResult<LoginResultDto>
                {
                    Code = CodeEnum.error,
                    Message = e.Message
                };
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/users/me")]
        public async Task<APIResult<PermissionDto>> InfoAsync()
        {
            var UserName = httpContextAccessor.HttpContext.User.Identity.Name;

            var User = await repositoryUser.FindAsync(m => m.Username == UserName);

            return new APIResult<PermissionDto>
            {
                Code = CodeEnum.success,
                Data = new PermissionDto
                {
                    Avatar = User.Avatar,
                    Nickname = User.Nickname,
                    Perms = new string[] {
                            "sys:menu:delete",
                            "sys:dept:edit",
                            "sys:dict_type:add",
                            "sys:dict:edit",
                            "sys:dict:delete",
                            "sys:dict_type:edit",
                            "sys:menu:add",
                            "sys:user:add",
                            "sys:role:edit",
                            "sys:dept:delete",
                            "sys:user:password_reset",
                            "sys:user:edit",
                            "sys:user:delete",
                            "sys:dept:add",
                            "sys:role:delete",
                            "sys:dict_type:delete",
                            "sys:menu:edit",
                            "sys:dict:add",
                            "sys:role:add"
                     },
                    Roles = new string[] { "ADMIN" },
                    UserId = User.Id,
                    Username = User.Username
                }
            };
        }

        ////上传头像
        //[HttpPost("/api/v1/users/avatar")]
        //public async Task<APIResult<string>> UploadAvatarAsync([FromForm] IFormFile file)
        //{
        //    try
        //    {
        //        var UserName = httpContextAccessor.HttpContext.User.Identity.Name;
        //        var User = await repositoryUser.FindAsync(m => m.Username == UserName);
        //        if (User == null)
        //        {
        //            return new APIResult<string> { Code = CodeEnum.error, Message = "用户未找到" };
        //        }
        //        else
        //        {
        //            var fileExt = file.FileName.Split('.')[1];
        //            var fileName = Guid.NewGuid().ToString() + "." + fileExt;
        //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", fileName);
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(stream);
        //            }
        //            User.Avatar = "/upload/" + fileName;
        //            await repositoryUser.UpdateAsync(User);
        //            return new APIResult<string>
        //            {
        //                Code = CodeEnum.success,
        //                Data = User.Avatar
        //            };
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        private LoginResultDto GenerateToken(SystemUser admin)
        {
            IList<Claim> claims = new List<Claim> {
                                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                                new Claim(ClaimTypes.Name, admin.Username)
                            };

            //JWT密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Bearer:SecurityKey"]));

            //算法
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //过期时间
            var expires = DateTime.UtcNow.AddHours(10);

            //Payload负载
            var token = new JwtSecurityToken(
                issuer: configuration["JwtConfig:Bearer:Issuer"],
                audience: configuration["JwtConfig:Bearer:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expires,
                signingCredentials: cred
                );

            var handler = new JwtSecurityTokenHandler();

            //生成令牌
            string jwt = handler.WriteToken(token);

            return new LoginResultDto
            {
                AccessToken = jwt,
                Expires = expires,
                RefreshToken = string.Empty,
                TokenType = JwtBearerDefaults.AuthenticationScheme
            };
        }

       
    }
}
