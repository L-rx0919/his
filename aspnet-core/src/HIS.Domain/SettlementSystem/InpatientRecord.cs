using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.SettlementSystem
{
    /// <summary>
    /// 住院记录
    /// </summary>
    public class InpatientRecord:FullAuditedAggregateRoot<Guid>
    {
        
        /// <summary>
        /// 病人ID
        /// </summary>
        public int patient_id { get; set; }
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
        public int department_id { get; set; }
        /// <summary>
        /// 主治医生ID
        /// </summary>
        public int doctor_id { get; set; }
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
