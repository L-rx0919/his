using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS
{
    public class SystemDept:FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 父节点id
        /// </summary>
        public Guid ParentId { get; set; }
        /// <summary>
        /// 父节点id路径
        /// </summary>
        public string TreePath { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 状态（1-正常，0-禁用）
        /// </summary>
        public Status Status { get; set; }
    }
}
