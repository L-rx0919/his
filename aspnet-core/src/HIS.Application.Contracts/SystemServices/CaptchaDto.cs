﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SystemServices
{
    public class CaptchaDto
    {
        public string captchaKey { get; set; }
        public string captchaBase64 { get; set; }
    }
}
