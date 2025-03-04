using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.System_Administration
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class SystemMenu: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int SystemMenuID { get; set; }
        /// <summary>
        /// 上级菜单ID
        /// </summary>
        public int Superior { get; set; }
        /// <summary>
        /// 英文菜单
        /// </summary>
        public string EnglishMenu { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string SystemMenuName { get; set; }
        /// <summary>
        /// 外部应用
        /// </summary>
        public string ExternalApplications { get; set; }


    }
}
