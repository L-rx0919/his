using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HIS
{
    /// <summary>
    /// 菜单DTO
    /// </summary>
    public class SysMenuDto
    {
        /// <summary>
        /// 路由路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 组件路径
        /// </summary>
        public string Component { get; set; }
        /// <summary>
        /// 重定向跳转路径
        /// </summary>
        public string Redirect { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 元数据
        /// </summary>
        public Meta Meta { get; set; }
        /// <summary>
        /// 组件列表
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<SysMenuDto> Children { get; set; }
    }

    public class Meta
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool Hidden { get; set; }
        /// <summary>
        /// 【目录】只有一个子路由是否始终显示（1-是 0-否）
        /// </summary>
        public bool AlwaysShow { get; set; }
        /// <summary>
        /// 是否缓存
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? KeepAlive { get; set; }
        /// <summary>
        /// 路由参数
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Params { get; set; }
    }
}
