using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public class SysMenu : FullAuditedEntityExt<Guid>
    {
        /// <summary>
        /// 父节点id
        /// </summary>
        public Guid ParentId { get; set; }
        /// <summary>
        /// 父节点id路径
        /// </summary>
        public string TreePath { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单类型（1-菜单 2-目录 3-外链 4-按钮）
        /// </summary>
        public MenuType Type { get; set; }
        /// <summary>
        /// 路由名称（Vue Router 中用于命名路由）
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 路由路径（Vue Router 中定义的 URL 路径）
        /// </summary>
        public string RoutePath { get; set; }
        /// <summary>
        /// 组件路径（组件页面完整路径，相对于 src/views/，缺省后缀 .vue）
        /// </summary>
        public string Component { get; set; }
        /// <summary>
        /// 【按钮】权限标识
        /// </summary>
        public string Perm { get; set; }
        /// <summary>
        /// 【目录】只有一个子路由是否始终显示（1-是 0-否）
        /// </summary>
        public AlwaysShow AlwaysShow { get; set; }
        /// <summary>
        /// 【菜单】是否开启页面缓存（1-是 0-否）
        /// </summary>
        public KeepAlive KeepAlive { get; set; }
        /// <summary>
        /// 显示状态（1-显示 0-隐藏）
        /// </summary>
        public Visible Visible { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 跳转路径
        /// </summary>
        public string Redirect { get; set; }
        /// <summary>
        /// 路由参数
        /// </summary>
        public string Params { get; set; }
    }
}
