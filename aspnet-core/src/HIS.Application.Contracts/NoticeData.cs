using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    /// <summary>
    /// 通知Dto
    /// </summary>
    public class NoticeDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsRead { get; set; }
        /// <summary>
        /// 通知级别:M/H/L低中高
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime { get; set; }
        /// <summary>
        /// 发布人
        /// </summary>
        public string PublishName { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 通知类型
        /// </summary>
        public NoticeType Type { get; set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }
    }

    public class NoticeData
    {
        public List<NoticeDto> List { get; set; }
    }
}
