using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel;

namespace HIS
{
    public enum Status
    {
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disabled,
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Enabled

    }
}
