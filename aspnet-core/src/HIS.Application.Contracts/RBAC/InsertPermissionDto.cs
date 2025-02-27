using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.RBAC
{
    /// <summary>
    /// 权限添加Dto
    /// </summary>
    public class InsertPermissionDto
    {
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionName { get; set; }
        /// <summary>
        /// 父级Id
        /// </summary>
        public Guid ParentId { get; set; }
    }
}
