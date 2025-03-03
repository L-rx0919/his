using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    /// <summary>
    /// 【菜单】是否开启页面缓存（1-是 0-否）
    /// </summary>
    public enum KeepAlive
    {
        /// <summary>
        /// 否
        /// </summary>
        [Description("否")]
        Hide = 0,
        /// <summary>
        /// 是
        /// </summary>
        [Description("是")]
        Show
    }
}
