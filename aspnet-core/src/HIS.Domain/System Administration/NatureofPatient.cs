using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.System_Administration
{
    /// <summary>
    /// 病人性质
    /// </summary>
    public class NatureofPatient: FullAuditedAggregateRoot<Guid>
    {
      
        /// <summary>
        /// 病人性质名称
        /// </summary>
        public string NatureofPatientName { get; set; }
        /// <summary>
        /// 性质代码
        /// </summary>
        public string Naturecode{ get; set; }
        /// <summary>
        /// 医保险种类型
        /// </summary>
        public string Typeinsurance { get; set; }
        /// <summary>
        /// 门诊住院标志
        /// </summary>    
        public string Hospitallogo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 性质类别(卡)
        /// </summary>
        public string NatureTypeCard { get; set; }
        /// <summary>
        /// 医保交易类型
        /// </summary>
        public string Medicaltype { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
