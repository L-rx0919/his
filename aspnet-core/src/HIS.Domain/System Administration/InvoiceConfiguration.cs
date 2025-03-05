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
    /// 发票配置
    /// </summary>
    public class InvoiceConfiguration:FullAuditedEntity<Guid>
    {
       
        public Guid InvoiceConfigurationID { get; set; }
        /// <summary>
        /// 首字母
        /// </summary>
        public string Initials { get; set; }
        /// <summary>
        /// 起始收据号
        /// </summary>
        public string InitialNumber { get; set; }
        /// <summary>
        /// 当前单据号
        /// </summary>
        public string Currentdocument { get; set; }
        /// <summary>
        /// 结束收据号
        /// </summary>
        public string Endnumber { get; set; }
        /// <summary>
        /// 领用日期
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
