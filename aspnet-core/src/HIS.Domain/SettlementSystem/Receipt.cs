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
    /// 票据
    /// </summary>
    public class Receipt : FullAuditedAggregateRoot<Guid>
    {
        
        /// <summary>
        /// 结算ID
        /// </summary>
        public string settlement_id { get; set; }
        /// <summary>
        /// 票据编号
        /// </summary>
        public string receipt_number { get; set; }
        /// <summary>
        /// 开具日期
        /// </summary>
        public DateTime receipt_date { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal amount { get; set; }
//        receipt_id：票据ID
//settlement_id：结算ID（外键）
//receipt_number：票据编号
//receipt_date：开具日期
//amount：金额
    }
}
