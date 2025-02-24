using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SettlementSystem
{
    /// <summary>
    /// 患者
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        [Key]
        public int patient_id { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string patient_name { get; set; }

        /// <summary>
        /// 患者性别
        /// </summary>
        [Required]
        [StringLength(10)]
        public string patient_gender { get; set; }

        /// <summary>
        /// 患者年龄
        /// </summary>
        [Required]
        public int patient_age { get; set; }

        /// <summary>
        /// 患者联系方式
        /// </summary>
        [Required]
        [StringLength(50)]
        public string patient_contact { get; set; }

        /// <summary>
        /// 患者住址
        /// </summary>
        [Required]
        [StringLength(200)]
        public string patient_address { get; set; }

        /// <summary>
        /// 患者血型
        /// </summary>
        [Required]
        [StringLength(10)]
        public string patient_blood_type { get; set; }
        /// <summary>
        /// 紧急联系人
        /// </summary>
        [StringLength(50)]
        public string emergency_contact { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string marital_status { get; set; }

    }
}
