using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.Notice
{
    /// <summary>
    /// 通知公告表
    /// </summary>
    public class SysNotice : FullAuditedEntityExt<Guid>
    {
        /// <summary>
        /// 通知标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 通知内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 目标类型（1: 全体, 2: 指定）
        /// </summary>
        public TargetType TargetType { get; set; }
        /// <summary>
        /// 目标人ID集合（多个使用英文逗号,分割）
        /// </summary>
        public string TargetUserIds { get; set; }
        /// <summary>
        /// 通知类型
        /// </summary>
        public NoticeType NoticeType { get; set; }
    }
}
