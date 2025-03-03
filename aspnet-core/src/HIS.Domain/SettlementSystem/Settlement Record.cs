using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.SettlementSystem
{
    /// <summary>
    /// 结算记录
    /// </summary>
    public class Settlement_Record : FullAuditedAggregateRoot<Guid>
    {
       
        /// <summary>
        /// 病人ID
        /// </summary>
        public string patient_id { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal total_amount { get; set; }
        /// <summary>
        /// 折扣金额
        /// </summary>
        public decimal discount { get; set; }
        /// <summary>
        /// 已支付金额
        /// </summary>
        public decimal payment_amount { get; set; }
        /// <summary>
        /// 未结余额
        /// </summary>
        public decimal outstanding_balance { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string payment_method { get; set; }
        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime settlement_date { get; set; }
        /// <summary>
        /// 结算状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 结算类型
        /// </summary>
        public string settlement_type { get; set; }
    }
//    settlement_id：结算ID
//patient_id：病人ID（外键）
//total_amount：总金额
//discount：折扣金额
//payment_amount：已支付金额
//outstanding_balance：未结余额
//payment_method：支付方式（现金、医保、银行转账等）
//settlement_date：结算日期
//status：结算状态（如已结算、待支付等）
//settlement_type：结算类型（如住院结算、门诊结算）
}
