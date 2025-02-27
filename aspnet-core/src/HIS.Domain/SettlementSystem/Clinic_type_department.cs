using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.SettlementSystem
{
    /// <summary>
    /// 门诊类型与科室关联表
    /// </summary>
    public class Clinic_type_department : FullAuditedAggregateRoot<Guid>
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
