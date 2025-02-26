using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.RBAC
{
    public class CaptchaDto
    {
        public string CaptchaKey { get; set; }
        public string CaptchaBase64 { get; set; }
    }
}
