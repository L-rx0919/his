using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.HIS.InpatientRecords
{
    /// <summary>
    /// 住院记录DTO
    /// </summary>
    public class InpatientRecordDto : FullAuditedAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 病人ID
        /// </summary>
        public Guid patient_id { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string patient_name { get; set; }
        /// <summary>
        /// 入院时间
        /// </summary>
        public DateTime admission_date { get; set; }

        /// <summary>
        /// 出院时间
        /// </summary>
        public DateTime discharge_date { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary>
        public Guid department_id { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string department_name { get; set; }
        /// <summary>
        /// 主治医生ID
        /// </summary>
        public Guid doctor_id { get; set; }
        /// <summary>
        /// 主治医生姓名
        /// </summary>
        public string doctor_name { get; set; }
        /// <summary>
        /// 病房类型
        /// </summary>
        public string room_type { get; set; }
        /// <summary>
        /// 入院信息
        /// </summary>
        public string admission_reason { get; set; }

        /// <summary>
        /// 是否住院
        /// </summary>

        public bool is_in_insurance { get; set; }
    }
}
