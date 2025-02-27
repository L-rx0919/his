using HIS.RBAC;
using Lazy.Captcha.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitManage.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;


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
        public async Task<APIResult1<UserDTO>> AddUser(UserDTO user)
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
                return new APIResult1<UserDTO>()
                {
                    Code = CodeEnum.success,
                    Message = "注册成功",
                }; ;
            }
            else
            {
                return new APIResult1<UserDTO>()
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
        public async Task<APIResult<UserDTO>> Login(string UserName, string UserPwd)
        {
            //查询用户
            var userlist = await Userrepository.GetAsync(c => c.UserName ==UserName);
            if (userlist == null)
            {
                return new APIResult<UserDTO>()
                {
                    Code = CodeEnum.error,
                    Message = "用户名或密码错误",
                };
            }
            else
            {
                // 检查用户是否被锁定
                if (userlist.UserIsLock)
                {
                    return new APIResult<UserDTO>()
                    {
                        Code = CodeEnum.error,
                        Message = "用户已锁定",
                    };
                }
                // 密码验证
                if (userlist.UserPwd != UserPwd)
                {
                    // 增加密码错误次数
                    userlist.UserErrorCount++;

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

                    // 如果锁定了，返回锁定信息
                    if (userlist.UserIsLock)
                    {
                        return new APIResult<UserDTO>()
                        {
                            Code = CodeEnum.error,
                            Message = "用户已锁定，密码错误次数超过限制。",
                        };
                    }
                    else
                    {
                        return new APIResult<UserDTO>()
                        {
                            Code = CodeEnum.error,
                            Message = $"密码错误，剩余尝试次数：{3 - userlist.UserErrorCount}",
                        };
                    }
                }
            }

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

            return new APIResult<UserDTO>()
            {
                Code = CodeEnum.success,
                Message = "登录成功",
                Data = userDTO
            };
        }
        /// <summary>
        ///  获取验证码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/captcha")]
        ///v1/auth
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
            return new APIResult1<CaptchaDto>
            {
                Code = CodeEnum.success,
                Data = captchaDto,
                Message = "获取验证码成功"
            };
        }
    }
}
