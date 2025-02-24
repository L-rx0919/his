using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    public class APIResult
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回状态码
        /// </summary>
        public CodeEnum Code { get; set; }

    }

    public class APIResult<T> : APIResult
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
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
