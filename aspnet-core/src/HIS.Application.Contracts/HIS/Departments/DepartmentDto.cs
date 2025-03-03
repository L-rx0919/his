using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.HIS.Departments
{
    public class DepartmentDto:FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 科室名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 科室位置
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 科室类型（如内科、外科、急诊等）
        /// </summary>

        public string department_type { get; set; }
    }
}
