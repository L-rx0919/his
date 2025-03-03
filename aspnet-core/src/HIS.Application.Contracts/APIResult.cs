using DocumentFormat.OpenXml.EMMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    public class APIResult<TData>
    {
        public CodeEnum Code { get; set; }
        public TData Data { get; set; }
        public string Msg { get; set; }
    }

    /// <summary>
    /// 返回状态码
    /// </summary>
    public enum CodeEnum
    {
        success = 0, // 成功
        error = 1, // 失败
        unauthorized = 2, // 未授权
        notfound = 3, // 未找到
    }
}
