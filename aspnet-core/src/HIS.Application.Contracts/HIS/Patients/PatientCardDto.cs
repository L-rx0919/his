using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.HIS.Patients
{
    public class PatientCardDto:FullAuditedAggregateRoot<Guid>
    {

     
        /// <summary>
        /// 患者姓名
        /// </summary>

        public string patient_name { get; set; }

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
        /// 病人ID
        /// </summary>
        public string Patient_id { get; set; }
        /// <summary>
        /// 卡状态
        /// </summary>
        public string Card_status { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string Card_type { get; set; }
    }
}
