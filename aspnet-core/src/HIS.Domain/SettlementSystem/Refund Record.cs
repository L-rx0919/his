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
    /// 退费记录表
    /// </summary>
    public class Refund_Record : FullAuditedAggregateRoot<Guid>
    {
      
        /// <summary>
        /// 结算ID
        /// </summary>
        public int settlement_id { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal refund_amount { get; set; }
        /// <summary>       
        /// 退款日期
        /// </summary>
        public DateTime refund_date { get; set; }
        /// <summary>
        /// 退款原因
        /// </summary>
        public string refund_reason { get; set; }   
//        refund_id：退款ID
//settlement_id：结算ID（外键）
//refund_amount：退款金额
//refund_date：退款日期
//refund_reason：退款原因（如重复收费、调整等）
    }
}
