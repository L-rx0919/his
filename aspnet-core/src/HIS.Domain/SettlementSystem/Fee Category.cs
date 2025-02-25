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
    /// 费用类别
    /// </summary>
    public class Fee_Category : FullAuditedAggregateRoot<Guid>
    {
       
        /// <summary>
        /// 类别名称
        /// </summary>
        public string category_name { get; set; }
//        category_id：费用类别ID
//category_name：类别名称（如门诊、住院、检查、药品等）
    }
}
