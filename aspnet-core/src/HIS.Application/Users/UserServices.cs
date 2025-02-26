using HIS.RBAC;
using Microsoft.AspNetCore.Mvc;
using System;
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

        /// <summary>
        /// 角色仓储
        /// </summary>
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
        /// 构造函数
        /// </summary>
        /// <param name="userrepository"></param>
        /// <param name="rolerepository"></param>
        /// <param name="rolePermissionsrepository"></param>
        /// <param name="userRolerepository"></param>
        /// <param name="permissionsrepository"></param>
        public UserServices(IRepository<HIS.RBAC.User> userrepository, IRepository<Role> rolerepository, IRepository<RolePermissions> rolePermissionsrepository, IRepository<UserRole> userRolerepository, IRepository<Permissions> permissionsrepository)
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
        public async Task<APIResult<UserDTO>> AddUser(UserDTO user)
        {
            var users = await Userrepository.AllAsync(c => c.UserName == user.UserName);
            if (users == true)
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
        /// 用户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        [HttpPost("api/Login")]
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

            // 登录成功，返回用户信息
            var userDTO = new UserDTO
            {
                UserName = userlist.UserName,
                UserId = userlist.Id,
            };

            return new APIResult<UserDTO>()
            {
                Code = CodeEnum.success,
                Message = "登录成功",
                Data = userDTO
            };
        }


    }
}
