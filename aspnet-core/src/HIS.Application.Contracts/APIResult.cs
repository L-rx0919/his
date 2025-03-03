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
        public string Message { get; set; }
    }

    /// <summary>
    /// 返回状态码
    /// </summary>
    public enum CodeEnum
    {
        success = 0, // 成功
        error = 500, // 失败
        unauthorized = 401, // 未授权
        notfound = 403, // 未找到
    }
}
