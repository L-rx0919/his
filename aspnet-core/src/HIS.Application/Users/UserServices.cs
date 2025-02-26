using HIS.Patients;
using HIS.RBAC;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.Users
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class UserServices : ApplicationService, IServicesUsers
    {
        private readonly IRepository<User> Userrepository;
        private readonly IRepository<Role> Rolerepository;
        private readonly IRepository<RolePermissions> RolePermissionsrepository;
        private readonly IRepository<UserRole> UserRolerepository;
        private readonly IRepository<Permissions> Permissionsrepository;

        public UserServices(IRepository<User> userrepository, IRepository<Role> rolerepository, IRepository<RolePermissions> rolePermissionsrepository, IRepository<UserRole> userRolerepository, IRepository<Permissions> permissionsrepository)
        {
            Userrepository = userrepository;
            Rolerepository = rolerepository;
            RolePermissionsrepository = rolePermissionsrepository;
            UserRolerepository = userRolerepository;
            Permissionsrepository = permissionsrepository;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("api/registration")]
        public async Task<APIResult> AddUser(UserDTO user)
        {
            var users = await Userrepository.FirstOrDefaultAsync(c => c.UserName == user.UserName);
            if (users == null)
            {
                var list = ObjectMapper.Map<UserDTO, User>(user);
                await Userrepository.InsertAsync(list);

                var userRole = new UserRole()
                {
                    UserId = list.Id,
                    RoleId = user.RoleId
                };
            }
            return new APIResult()
            {
                Code = CodeEnum.success,
                Message = "注册成功",
            }; ;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("api/Login")]
        public async Task<APIResult<UserDTO>> Login(string UserName, string UserPwd)
        {
            var user = await Userrepository.GetAsync(c => c.UserName == UserName);

            if (user == null)
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
                if (user.UserIsLock)
                {
                    return new APIResult<UserDTO>()
                    {
                        Code = CodeEnum.error,
                        Message = "用户已锁定",
                    };
                }

                // 密码验证
                if (user.UserPwd != UserPwd)
                {
                    // 增加密码错误次数
                    user.UserErrorCount++;

                    // 如果错误次数超过或等于3次，锁定用户
                    if (user.UserErrorCount >= 3)
                    {
                        user.UserIsLock = true;
                    }

                    // 更新用户的错误次数及锁定状态
                    await Userrepository.UpdateAsync(user);

                    // 如果锁定了，返回锁定信息
                    if (user.UserIsLock)
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
                            Message = $"密码错误，剩余尝试次数：{3 - user.UserErrorCount}",
                        };
                    }
                }
            }

            // 登录成功
            return new APIResult<UserDTO>()
            {
                Code = CodeEnum.success,
                Message = "登录成功",
            };
        }

    }
}
