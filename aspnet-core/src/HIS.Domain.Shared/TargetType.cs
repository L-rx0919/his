using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    /// <summary>
    /// 目标类型（1: 全体, 2: 指定）
    /// </summary>
    public enum TargetType
    {
        /// <summary>
        /// 全体
        /// </summary>
        [Description("全体")]
        All,
        /// <summary>
        /// 指定
        /// </summary>
        [Description("指定")]
        Specify
    }
}
