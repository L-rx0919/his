using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.RBAC
{
    /// <summary>
    /// RBAC接口
    /// </summary>
    public interface IServicesUsers
    {
        /// <summary>
        /// 异步添加新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<APIResult> AddUser(UserDTO user);

        ///// <summary>
        ///// 异步用户登录
        ///// </summary>
        ///// <param name="UserName"></param>
        ///// <param name="UserPwd"></param>
        ///// <returns></returns>
        //Task<APIResult> Login(string UserName,string UserPwd);
    }
}
