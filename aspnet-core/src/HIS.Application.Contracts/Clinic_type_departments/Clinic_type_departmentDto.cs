using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.Clinic_type_departments
{
    public class Clinic_type_departmentDto : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 门诊类型ID
        /// </summary>
        public string clinic_type_id { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary>
        public string department_id { get; set; }
    }
}
