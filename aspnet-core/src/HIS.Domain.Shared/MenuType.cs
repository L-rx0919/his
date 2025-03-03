using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    /// <summary>
    /// 菜单类型（1-菜单 2-目录 3-外链 4-按钮）
    /// </summary>
    public enum MenuType
    {
        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        Menu,
        /// <summary>
        /// 目录
        /// </summary>
        [Description("目录")]
        Dir,
        /// <summary>
        /// 外链
        /// </summary>
        [Description("外链")]
        ExtLink,
        /// <summary>
        /// 按钮
        /// </summary>
        [Description("按钮")]
        Button
    }
}
