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
    /// 支付方式
    /// </summary>
    public class Payment_Method:FullAuditedAggregateRoot<Guid>
    {
     

        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string method_name { get; set; }
        /// <summary>
        /// 支付方式描述
        /// </summary>
        public string description { get; set; }
        //        payment_method_id：支付方式ID
        //method_name：支付方式名称（现金、银行卡、医保等）
        //description：支付方式描述
    }
}
