using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SystemDicServices
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParamsDto
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageNum { get; set; } = 1;
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; } = 10;
    }

    /// <summary>
    /// 分页查询参数
    /// </summary>
    public class PageAndQueryParamsDto : PageParamsDto
    {
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keywords { get; set; }
    }

    /// <summary>
    /// 分页和时间范围查询参数
    /// </summary>
    public class PageAndQueryAndTimeRange : PageAndQueryParamsDto
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 分页返回结果DTO
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class PageResultDto<TData>
    {
        /// <summary>
        /// 当前页数据
        /// </summary>
        public List<TData> List { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }
    }
}
