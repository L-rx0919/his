using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.RBAC
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class CaptchaDto
    {
        /// <summary>
        /// 验证码Key  
        /// </summary>
        public string CaptchaKey { get; set; }
        /// <summary>
        /// 验证码Base64   
        /// </summary>
        public string CaptchaBase64 { get; set; }
    }
}
