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
    /// 账单表
    /// </summary>
    public class Hospital_Bill:FullAuditedAggregateRoot<Guid>
    {
       
        /// <summary>
        ///     住院记录ID
        /// </summary>
        public Guid record_id { get; set; }
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

    }
}
