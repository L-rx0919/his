using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    /// <summary>
    /// API结果
    /// </summary>
    public class ResultDto
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuc { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 结果代码
        /// </summary>
        public ResultCode Code { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isSuc">是否成功</param>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <param name="code"> 结果代码</param>
        public ResultDto(bool isSuc, string msg, object data, ResultCode code)
        {
            IsSuc = isSuc;
            Msg = msg;
            Data = data;
            Code = code;
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResultDto OK(object data = null, string msg = "操作成功")
        {
            return new ResultDto(true, msg, data, ResultCode.Success);
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResultDto Fail(string msg = "操作失败")
        {
            return new ResultDto(false, msg, null, ResultCode.Fail);
        }
    }
    /// <summary>
    /// 枚举
    /// </summary>
    public enum ResultCode
    {
        Success = 200,
        Fail = 500,
    }
}
