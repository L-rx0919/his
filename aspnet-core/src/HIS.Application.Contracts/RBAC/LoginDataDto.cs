using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.RBAC
{
    public class LoginDataDto
    {
        //头像
        public string Avatar { get; set; }
        public string Nickname { get; set; }
        public string Perms { get; set; } = "[]";

        public string Roles { get; set; } 
        public Guid UserId { get; set; }
        public string username { get; set; }
    }
}
