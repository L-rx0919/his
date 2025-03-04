using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.System_Administration
{
    /// <summary>
    /// 收费项目表
    /// </summary>
    public class Itemscharged : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 收费项目ID
        /// </summary>
        public int ItemschargedID { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public string ItemschargedOrganization { get; set; }
        /// <summary>
        /// 诊疗组合名称
        /// </summary>
        public string HealingPackageName { get; set; }
        /// <summary>
        /// 诊疗组合编码
        /// </summary>
        public string Codingpackages { get; set; }
        /// <summary>
        /// 明细项目排序
        /// </summary>
        public string Detailsorting { get; set; }
        /// <summary>
        /// 诊疗明细项目名称
        /// </summary>
        public string Diagnosisprojectname { get; set; }
    }
}
