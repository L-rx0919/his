using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS
{
    public class SysDictData:FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 关联字典编码，与sys_dict表中的dict_code对应
        /// </summary>
        public string DictCode { get; set; }
        /// <summary>
        /// 字典项值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 字典项标签
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 标签类型，用于前端样式展示（如success、warning等）
        /// </summary>
        public string TagType { get; set; }
        /// <summary>
        /// 状态（1-正常，0-禁用）
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
