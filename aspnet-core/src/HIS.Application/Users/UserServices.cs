using HIS.RBAC;
using Lazy.Captcha.Core;
using Microsoft.AspNetCore.Mvc;
using RabbitManage.EntityFrameworkCore;
using System;
using System.IO;
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

        public UserServices(IRepository<HIS.RBAC.User> userrepository, IRepository<Role> rolerepository, IRepository<RolePermissions> rolePermissionsrepository, IRepository<UserRole> userRolerepository, IRepository<Permissions> permissionsrepository, ICaptcha captcha = null)
        {
            Userrepository = userrepository;
            Rolerepository = rolerepository;
            RolePermissionsrepository = rolePermissionsrepository;
            UserRolerepository = userRolerepository;
            Permissionsrepository = permissionsrepository;
            this.captcha = captcha;
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
        /// 用户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/auth/Login")]
        public async Task<APIResult1<UserDTO>> Login(string UserName, string UserPwd)
        {
            //查询用户
            var userlist = await Userrepository.GetAsync(c => c.UserName == UserName);
            if (userlist == null)
            {
                return new APIResult1<UserDTO>()
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
                    return new APIResult1<UserDTO>()
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

                    // 如果错误次数超过或等于3次，锁定用户
                    if (userlist.UserErrorCount >= 3)
                    {
                        userlist.UserIsLock = true;
                    }

                    // 更新用户的错误次数及锁定状态
                    await Userrepository.UpdateAsync(userlist);

                    // 如果锁定了，返回锁定信息
                    if (userlist.UserIsLock)
                    {
                        return new APIResult1<UserDTO>()
                        {
                            Code = CodeEnum.error,
                            Message = "用户已锁定，密码错误次数超过限制。",
                        };
                    }
                    else
                    {
                        return new APIResult1<UserDTO>()
                        {
                            Code = CodeEnum.error,
                            Message = $"密码错误，剩余尝试次数：{3 - userlist.UserErrorCount}",
                        };
                    }
                }
            }

            // 登录成功，返回用户信息
            var userDTO = new UserDTO
            {
                UserName = userlist.UserName,
                UserId = userlist.Id,
            };

            return new APIResult1<UserDTO>()
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
        [HttpGet("/api/v1/auth/captcha")]
        public APIResult1<CaptchaDto> Captcha(string id)
        {
            var captchaCode = captcha.Generate(id);
            var stream = new MemoryStream(captchaCode.Bytes);
            var base64 = $"data:image/png;base64,{Convert.ToBase64String(stream.ToArray())}";
            var captchaDto = new CaptchaDto
            {
                CaptchaKey = Guid.NewGuid().ToString("n"),
                CaptchaBase64 = base64
            };
            return new APIResult1<CaptchaDto>
            {
                Code = CodeEnum.success,
                Data = captchaDto,
                Message = "获取验证码成功"
            };
        }


        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="insertRoleDto"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/auth/Role")]
        public async Task<APIResult1<InsertRoleDto>> InsertRole(InsertRoleDto insertRoleDto)
        {

            var role = ObjectMapper.Map<InsertRoleDto, Role>(insertRoleDto);
            await Rolerepository.InsertAsync(role);
            return new APIResult1<InsertRoleDto>()
            {
                Code = CodeEnum.success,
                Message = "添加成功",
            };
        }

        /// <summary>
        /// 权限添加
        /// </summary>
        /// <param name="insertPermissionDto"></param>
        /// <returns></returns>
       [HttpPost("/api/v1/auth/Permissions")]
       public async Task<APIResult1<InsertPermissionDto>> InsertPermission(InsertPermissionDto insertPermissionDto)
        {
            var permission = ObjectMapper.Map<InsertPermissionDto, Permissions>(insertPermissionDto);
            await Permissionsrepository.InsertAsync(permission);
            return new APIResult1<InsertPermissionDto>()
            {
                Code = CodeEnum.success,
                Message = "添加成功",
            };
        }

        /// <summary>
        /// 角色权限添加
        /// </summary>
        /// <param name="insertRolePermissionsDto"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/auth/InsertRolePermissions")]
        public async Task<APIResult1<RolePermissionDTO>> InsertRolePermissions(RolePermissionDTO insertRolePermissionsDto)
        {
            var rolePermissions = ObjectMapper.Map<RolePermissionDTO, RolePermissions>(insertRolePermissionsDto);
            await RolePermissionsrepository.InsertAsync(rolePermissions);
            return new APIResult1<RolePermissionDTO>()
            {
                Code = CodeEnum.success,
                Message = "添加成功",
            };
        }

        /// <summary>
        /// 用户角色添加
        /// </summary>
        /// <param name="insertUserRoleDto"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/auth/InsertUserRole")]
        public async Task<APIResult1<UserRoleDto>> InsertUserRole(UserRoleDto insertUserRoleDto)
        {
            var userRole = ObjectMapper.Map<UserRoleDto, UserRole>(insertUserRoleDto);
            await UserRolerepository.InsertAsync(userRole);
            return new APIResult1<UserRoleDto>()
            {
                Code = CodeEnum.success,
                Message = "添加成功",
            };
        }



    }
}
