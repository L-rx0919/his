using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.System_Administration
{
    /// <summary>
    /// 科室医生表
    /// </summary>
    public class DepartmentDocto:FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 科室医生Id
        /// </summary>
        public int DepartmentDoctoId { get; set; }
        /// <summary>
        /// 科室
        /// </summary>
        public string Department {  get; set; }
        /// <summary>
        /// 医生
        /// </summary>
        public string Doctor { get; set; }
    }
}
