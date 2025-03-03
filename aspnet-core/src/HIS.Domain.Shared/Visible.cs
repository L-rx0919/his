using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    /// <summary>
    /// 显示状态（1-显示 0-隐藏）
    /// </summary>
    public enum Visible
    {
        /// <summary>
        /// 隐藏
        /// </summary>
        [Description("隐藏")]
        Hide = 0,
        /// <summary>
        /// 显示
        /// </summary>
        [Description("显示")]
        Show
    }
}
