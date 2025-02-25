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
    /// 收费模块
    /// </summary>
    public class Chargingmodule : FullAuditedEntity<Guid>
    {

        /// <summary>
        /// 权限科室ID
        /// </summary>
        public int DepartmentID { get; set; }
        /// <summary>
        /// 模版名称
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// 单次治疗量
        /// </summary>
        public int Singltreatment { get; set; }
        /// <summary>
        /// 执行次数
        /// </summary>
        public int NumberCutions { get; set; }
        /// <summary>
        /// 康复类别
        /// </summary>
        public int TypeRehabil { get; set; }
        /// <summary>
        /// 部位
        /// </summary>
        public string Parts { get; set; }
        /// <summary>
        /// 单位时长
        /// </summary>
        public DateTime Unittime { get; set; }
    }
}
