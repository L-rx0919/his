using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.System_Administration
{
    /// <summary>
    /// 财务发票表
    /// </summary>
    public class FinancialInvoices : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 财务发票ID
        /// </summary>
        public int FinancialInvoicesID { get; set; }
        /// <summary>
        /// 首字母
        /// </summary>
        public string FinancialInvoicesinitial { get; set; }
        /// <summary>
        /// 起始发票号
        /// </summary>
        public string Initialinvoicenumber { get; set; }
        /// <summary>
        /// 当前发票号
        /// </summary>
        public string Currentinvoicenumber { get; set; }
        /// <summary>
        /// 结束发票号
        /// </summary>
        public string Endinvoicenumber { get; set; }
        /// <summary>
        /// 领用人员
        /// </summary>
        public string recipient { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string FinancialType { get; set; }
        /// <summary>
        /// 领用日期
        /// </summary>
        public DateTime FinancialTime { get; set; }
    }
}
