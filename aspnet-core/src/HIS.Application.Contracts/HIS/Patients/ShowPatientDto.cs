using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.HIS.Patients
{
    public class ShowPatientDto
    {
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string patient_name { get; set; }
        /// <summary>
        /// 收费日期
        /// </summary>
        public DateTime charge_date { get; set; }
        /// <summary>
        /// 病历号
        /// </summary>
        public string medical_record_number { get; set; }
        /// <summary>
        /// 门诊号
        /// </summary>
        public string outpatient_number { get; set; }
    }
}
