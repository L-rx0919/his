using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.SettlementSystem
{
    /// <summary>
    /// 门诊类型与医生排班表
    /// </summary>
    public class Clinic_type_schedule: FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 门诊类型ID
        /// </summary>
        public string clinic_type_id { get; set; }
        /// <summary>
        /// 医生ID
        /// </summary>
        public string doctor_id { get; set; }
        /// <summary>
        /// 排班日期
        /// </summary>
        public DateTime schedule_date { get; set; }
        /// <summary>
        /// 时段（如“08:00-12:00”）
        /// </summary>
        public string time_slot { get; set; }
        /// <summary>
        /// 剩余可挂号数量
        /// </summary>
        public int remaining_slots { get; set; }
    }
}
