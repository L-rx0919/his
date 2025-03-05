using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.HIS.PatientCenters
{
    public class PatientCenterDto
    {
        /// <summary>
        ///    医生姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary>
        public Guid department_id { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 专科
        /// </summary>
        public string specialty { get; set; }



        /// <summary>
        /// 科室名称
        /// </summary>
        public string key_department_name { get; set; }

        /// <summary>
        /// 科室位置
        /// </summary>
        public string key_department_location { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string key_department_phone { get; set; }
        /// <summary>
        /// 科室类型（如内科、外科、急诊等）
        /// </summary>

        public string department_type { get; set; }

        /// <summary>
        /// 患者编号
        /// </summary>
        public int Patientid { get; set; }
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

        /// <summary>
        /// 卡状态
        /// </summary>
        public string Card_status { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string Card_type { get; set; }
        /// <summary>
        /// 当前余额
        /// </summary>
        [Column(TypeName = "decimal(10,2)")]
        public decimal Balance { get; set; }
        /// <summary>
        /// 卡片创建日期
        /// </summary>
        public DateTime Create_date { get; set; }
        /// <summary>
        /// 卡片有效期日期
        /// </summary>
        public DateTime Expiry_date { get; set; }
        /// <summary>
        /// 上次交易日期
        /// </summary>
        public DateTime Last_transaction_date { get; set; }
        /// <summary>
        /// 卡片持有者姓名（如果是病人代表家属）
        /// </summary>
        [StringLength(50)]
        public string Card_owner_name { get; set; }
        /// <summary>
        /// 所属科室（如门诊、住院部等）
        /// </summary>
        public string Associated_dept { get; set; }
        /// <summary>
        ///  联系电话
        /// </summary>
        [StringLength(50)]
        public string Contact_phone { get; set; }
        /// <summary>
        /// 备注信息（如挂失原因、特殊要求等)
        /// </summary>
        [StringLength(300)]
        public string remarks { get; set; }
    }
}
