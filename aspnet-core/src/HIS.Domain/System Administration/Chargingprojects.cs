using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.System_Administration
{
    /// <summary>
    /// 收费项目表
    /// </summary>
    public class Chargingprojects
    {
        /// <summary>
        /// 收费项目ID
        /// </summary>
        [Key]
        public int ChargingprojectsID { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public int Organization { get; set; }
        /// <summary>
        /// 诊疗组合名称
        /// </summary>
        public string HealinName { get; set; }
        /// <summary>
        /// 诊疗组合编码
        /// </summary>
        public string Codingpackages { get; set; }
        /// <summary>
        /// 明细项目排序
        /// </summary>
        public string Detailed { get; set; }
        /// <summary>
        /// 诊疗明细项目名称
        /// </summary>
        public string DiagnosisName { get; set; }
    }
}
