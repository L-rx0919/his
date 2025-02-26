using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.RBAC
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        ///密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string UserNickName { get; set; }
        /// <summary>
        ///错误次数
        /// </summary>
        public int UserErrorCount { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool UserIsLock { get; set; }
    }
}
