using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SettlementSystem
{
    public class Hospital_Bill
    {
        /// <summary>
        ///     账单ID
        /// </summary>
        [Key]
        public int bill_id { get; set; }
        /// <summary>
        ///     病人ID
        /// </summary>  
        public int patient_id { get; set; }
        /// <summary>
        ///     住院记录ID
        /// </summa
        public int record_id { get; set; }
          /// <summary>
        ///     总金额
        /// </summary>
        public decimal total_amount { get; set; }
        /// <summary>
        ///     已支付金额
        /// </summary>
        public decimal amount_paid { get; set; }
        /// <summary>
        ///     未支付余额
        /// </summary>
        public decimal outstanding_balance { get; set; }
        /// <summary>
        ///     账单生成日期
        /// </summary>
        public DateTime bill_date { get; set; }
//        bill_id：账单ID
//patient_id：病人ID（外键）
//record_id：住院记录ID（外键）
//total_amount：总金额
//amount_paid：已支付金额
//outstanding_balance：未支付余额
//bill_date：账单生成日期
    }
}
