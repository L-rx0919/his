using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.Notice
{
    /// <summary>
    /// 用户通知公告
    /// </summary>
    public class SysUserNotice : FullAuditedEntityExt<Guid>
    {
        /// <summary>
        /// 通知ID
        /// </summary>
        public Guid NoticeId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead { get; set; }
    }
}
