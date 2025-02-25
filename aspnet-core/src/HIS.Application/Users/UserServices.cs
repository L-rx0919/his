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
            if (users==null)
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

        //public Task<APIResult> Login(string UserName, string UserPwd)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
