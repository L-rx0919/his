using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    public enum NoticeType
    {
        /// <summary>
        /// 系统升级
        /// </summary>
        [Description("系统升级")]
        Upgrade = 1,
        /// <summary>
        /// 系统维护
        /// </summary>
        [Description("系统维护")]
        Maintain = 2,
        /// <summary>
        /// 安全警告
        /// </summary>
        [Description("安全警告")]
        Warning = 3,
        /// <summary>
        /// 假期通知
        /// </summary>
        [Description("假期通知")]
        Notice = 4,
        /// <summary>
        /// 公司新闻
        /// </summary>
        [Description("公司新闻")]
        News = 5,
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 99
    }
}
