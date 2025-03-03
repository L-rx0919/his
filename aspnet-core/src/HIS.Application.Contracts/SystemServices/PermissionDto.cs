using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SystemServices
{
    public class PermissionDto
    {
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 当前用户权限
        /// </summary>
        public string[] Perms { get; set; }
        /// <summary>
        /// 当前用户角色
        /// </summary>
        public string[] Roles { get; set; }
        /// <summary>
        /// 当前用户Id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
    }
}
