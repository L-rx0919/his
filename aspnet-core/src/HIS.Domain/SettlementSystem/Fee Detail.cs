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
    /// 结算明细
    /// </summary>
    public class Fee_Detail:FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        ///         费用项目ID
        /// </summary>
            public int item_id { get; set; }
        /// <summary>
        ///         数量
        /// </summary>
            public int quantity { get; set; }
    }
//    detail_id：费用明细ID
//settlement_id：结算ID（外键）
//item_id：费用项目ID（外键）
//quantity：数量
//amount：金额
}
