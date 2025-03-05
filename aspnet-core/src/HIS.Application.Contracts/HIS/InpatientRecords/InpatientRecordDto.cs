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




        /// <summary>
        /// 患者性别
        /// </summary>

        public string patient_gender { get; set; }

        /// <summary>
        /// 患者年龄
        /// </summary>

        public int patient_age { get; set; }

        /// <summary>
        /// 患者联系方式
        /// </summary>

        public string patient_contact { get; set; }

        /// <summary>
        /// 患者住址
        /// </summary>

        public string patient_address { get; set; }

        /// <summary>
        /// 患者血型
        /// </summary>

        public string patient_blood_type { get; set; }
        /// <summary>
        /// 紧急联系人
        /// </summary>

        public string emergency_contact { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string marital_status { get; set; }




        /// <summary>
        /// 职称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 专科
        /// </summary>
        public string specialty { get; set; }
    }
}
