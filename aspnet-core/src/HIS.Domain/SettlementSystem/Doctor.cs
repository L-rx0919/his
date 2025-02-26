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
    /// 医生表
    /// </summary>
   public class Doctor : FullAuditedAggregateRoot<Guid>
    {
        
        /// <summary>
        ///     医生姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public string title { get; set; }   
        /// <summary>
        /// 科室ID
        /// </summary>
        public int department_id { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 专科
        /// </summary>
        public string specialty { get; set; }
    }
}

//doctor_id：医生ID
//name：医生姓名
//title：职称（如主任医师、副主任医师等）
//department_id：科室ID（外键）
//phone：联系电话
//specialty：专科