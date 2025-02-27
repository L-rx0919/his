using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.RBAC
{
    public class LoginDto
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码Key
        /// </summary>
        public string CaptchaKey { get; set; }
        /// <summary>
        /// 验证码值
        /// </summary>
        public string CaptchaCode { get; set; }
    }
}
