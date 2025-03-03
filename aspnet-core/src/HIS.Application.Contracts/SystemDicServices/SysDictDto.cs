using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SystemDicServices
{
    /// <summary>
    /// 字典DTO
    /// </summary>
    public class SysDictDto
    {
        /// <summary>
        /// 字典编码
        /// </summary>
        public string DictCode { get; set; }
        /// <summary>
        /// 类型编码
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 字典列表
        /// </summary>
        public List<SysDictDataDto> SysDictDataDtos { get; set; }
    }

    public class SysDictDataDto
    {
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
    }
}
