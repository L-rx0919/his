using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.System_Administration
{
    /// <summary>
    /// 系统动态表
    /// </summary>
    public class SystemDynamics: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 系统动态ID
        /// </summary>
        public int SystemDynamicsID { get; set; }
        /// <summary>
        /// 系统动态名称
        /// </summary>
        public string SystemDynamicsName { get; set; }

        ///<summary>
        ///系统编码
        /// </summary>
        public string SystemDynamicsEncoding { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string SystemDynamicsValue { get; set; }

        /// <summary>
        /// 系统动态说明
        /// </summary>
        public string SystemDynamicsNotes { get; set; }
        /// <summary>
        /// 系统动态排序
        /// </summary>
        public string SystemDynamicssort { get; set; }

        /// <summary>
        /// 系统动态类型
        /// </summary>
        public string SystemDynamicsType { get; set; }

    }
}
