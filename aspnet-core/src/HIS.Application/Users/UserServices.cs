using HIS.RBAC;
using Lazy.Captcha.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;


namespace HIS.Users
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class UserServices : ApplicationService, IServicesUsers
    {
        /// <summary>
        /// 用户仓储
        /// </summary>
        private readonly IRepository<User> Userrepository;
        private readonly ICaptcha captcha;

        private readonly IRepository<Role> Rolerepository;
        /// <summary>
        /// 角色权限仓储
        /// </summary>
        private readonly IRepository<RolePermissions> RolePermissionsrepository;
        /// <summary>
        /// 用户角色仓储
        /// </summary>
        private readonly IRepository<UserRole> UserRolerepository;
        /// <summary>
        /// 权限仓储
        /// </summary>
        private readonly IRepository<Permissions> Permissionsrepository;
        /// <summary>
        ///  Http上下文访问器 
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;
        public UserServices(IRepository<HIS.RBAC.User> userrepository, IRepository<Role> rolerepository, IRepository<RolePermissions> rolePermissionsrepository, IRepository<UserRole> userRolerepository, IRepository<Permissions> permissionsrepository, ICaptcha captcha = null, IHttpContextAccessor httpContextAccessor = null)
        {
            Userrepository = userrepository;
            Rolerepository = rolerepository;
            RolePermissionsrepository = rolePermissionsrepository;
            UserRolerepository = userRolerepository;
            Permissionsrepository = permissionsrepository;
            this.captcha = captcha;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("api/registration")]
        public async Task<APIResult<UserDTO>> AddUser(UserDTO user)
        {
            var users = await Userrepository.AllAsync(c => c.UserName == user.UserName);
            if (users == false)
            {
                var list = ObjectMapper.Map<UserDTO, HIS.RBAC.User>(user);
                await Userrepository.InsertAsync(list);

                var userRole = new UserRole()
                {
                    UserId = list.Id,
                    RoleId = user.RoleId
                };
                return new APIResult<UserDTO>()
                {
                    Code = CodeEnum.success,
                    Message = "注册成功",
                }; ;
            }
            else
            {
                return new APIResult<UserDTO>()
                {
                    Code = CodeEnum.error,
                    Message = "注册失败",
                }; ;
            }
        }

        /// <summary>
        ///  登录
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/auth/Login")]
        public  APIResult<LoginResult> LoginAsync([FromForm] LoginDto loginDto)
        {

            var result = captcha.Validate($"captcha:{loginDto.CaptchaKey}", loginDto.CaptchaCode);

            // 验证码正确，开始登录验证
            // 先检查用户是否存在    

            return new APIResult<LoginResult>()
            {
                Code = CodeEnum.success,
                Message = "登录成功",
                Data = new LoginResult()
                {
                    accessToken = "accessToken",
                    refreshToken = "refreshToken",
                    tokenType = "Bearer",
                    expiresIn = 1200
                }
            };
            #region 原有代码
            ////查询用户
            //var userlist =await Userrepository.GetAsync(c => c.UserName == loginDto.UserName);

            //if (userlist == null)
            //{
            //    return new APIResult<LoginResult>()
            //    {
            //        Code = CodeEnum.error,
            //        Message = "用户名或密码错误",
            //    };
            //}
            //else
            //{
            //    // 检查用户是否被锁定
            //    if (userlist.UserIsLock)
            //    {
            //        return new APIResult<LoginResult>()
            //        {
            //            Code = CodeEnum.error,
            //            Message = "用户已锁定",

            //        };
            //    }
            //    // 密码验证
            //    if (userlist.UserPwd != loginDto. Password)
            //    {
            //        // 增加密码错误次数
            //        userlist.UserErrorCount++;

            //        // 如果错误次数超过或等于3次，锁定用户
            //        if (userlist.UserErrorCount >= 3)
            //        {
            //            userlist.UserIsLock = true;
            //        }

            //        // 更新用户的错误次数及锁定状态
            //        await Userrepository.UpdateAsync(userlist);

            //        // 如果锁定了，返回锁定信息
            //        if (userlist.UserIsLock)
            //        {
            //            return new APIResult<LoginResult>()
            //            {
            //                Code = CodeEnum.error,
            //                Message = "用户已锁定，密码错误次数超过限制。",
            //            };
            //        }
            //        else
            //        {
            //            return new APIResult<LoginResult>()
            //            {
            //                Code = CodeEnum.error,
            //                Message = $"密码错误，剩余尝试次数：{3 - userlist.UserErrorCount}",

            //            };
            //        }
            //    }
            //}
            //// 登录成功，返回用户信息
            //var userDTO = new UserDTO
            //{
            //    UserName = userlist.UserName,
            //    UserId = userlist.Id,
            //};

            //return new APIResult<LoginResult>()
            //{
            //    Code = CodeEnum.success,
            //    Message = "登录成功",
            //    Data = new LoginResult()
            //    {
            //        accessToken = "",
            //        refreshToken = "",
            //        tokenType = "",
            //        expiresIn = 1200
            //    }
            //};

            return null;
            #endregion
        }
        /// <summary>
        ///  获取验证码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/auth/captcha")]
        public APIResult<CaptchaDto> Captcha(string id)
        {
            string guid = $"captcha:{Guid.NewGuid().ToString("N")}";
            //var captchaCode = captcha.Generate(id);
            var captchaCode = captcha.Generate(id, 120);
            httpContextAccessor.HttpContext.Response.Cookies.Append("ValidateCode", guid);
            var stream = new System.IO.MemoryStream(captchaCode.Bytes);

            var captchaDto = new CaptchaDto
            {
                CaptchaKey = Guid.NewGuid().ToString("n"),
                CaptchaBase64 = $"data:image/png;base64,{Convert.ToBase64String(stream.ToArray())}"
            };
            return new APIResult<CaptchaDto>
            {
                Code = CodeEnum.success,
                Data = captchaDto,
                Message = "获取验证码成功"
            };
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        [HttpGet("api/v1/users/me")]
        public async Task<APIResult<List<LoginDataDto>>> GetUserAsync()
        {
            

                var users = await Userrepository.GetQueryableAsync();
                var userRoles = await UserRolerepository.GetQueryableAsync();
                var roles = await Rolerepository.GetQueryableAsync();
                var rolePermissions = await RolePermissionsrepository.GetQueryableAsync();
                var permissions = await Permissionsrepository.GetQueryableAsync();

                var dto = from u in users
                          join ur in userRoles on u.Id equals ur.UserId
                          join r in roles on ur.RoleId equals r.Id
                          join rp in rolePermissions on r.Id equals rp.RoleId
                          join p in permissions on rp.PermissionId equals p.Id
                          where u.Id == u.Id
                          select new LoginDataDto()
                          {
                              username = u.UserName,
                              UserId = u.Id,
                              Roles = r.RoleName,
                              Perms = p.PermissionName,
                              Avatar = "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif",
                              Nickname = u.UserNickName
                          };

               
                return new APIResult<List<LoginDataDto>>()
                {
                    Code = CodeEnum.success,
                    Message = "获取用户信息成功",
                    Data = dto.ToList()
                };
            }
        
    }
}
