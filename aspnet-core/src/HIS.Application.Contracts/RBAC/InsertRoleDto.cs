using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.RBAC
{

    /// <summary>
    /// 角色添加Dto
    /// </summary>
    public class InsertRoleDto:FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
    }
}
