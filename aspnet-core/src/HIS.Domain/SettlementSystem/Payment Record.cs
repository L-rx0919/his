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
    /// 支付记录
    /// </summary>
    public class Payment_Record : FullAuditedAggregateRoot<Guid>
    {
       
        /// <summary>
        ///       结算ID（外键）
        /// </summary>
        public int settlement_id { get; set; }
        /// <summary>
        ///       支付金额
        /// </summary>
        public decimal amount { get; set; }
        /// <summary>
        ///       支付方式（现金、医保、银行卡等）
        /// </summary>
        public string payment_method { get; set; }
        /// <summary>
        ///       支付日期
        /// </summary>
        public DateTime payment_date { get; set; }
//        payment_id：支付记录ID
//settlement_id：结算ID（外键）
//amount：支付金额
//payment_method：支付方式（现金、医保、银行卡等）
//payment_date：支付日期
    }
}
