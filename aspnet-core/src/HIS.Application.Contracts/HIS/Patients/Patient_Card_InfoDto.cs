using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.HIS.Patients
{
    public class Patient_Card_InfoDto:FullAuditedAggregateRoot<Guid>
    {
        
        public string Patient_id { get; set; }
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
