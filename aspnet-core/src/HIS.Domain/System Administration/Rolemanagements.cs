using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.System_Administration
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class Rolemanagements : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RolemanagementsID { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public string Theorganization {  get; set; }
        /// <summary>
        /// 角色管理名称
        /// </summary>
        public string RolemanagementsName { get; set; }
        /// <summary>
        /// 角色管理编码
        /// </summary>
        public string Encoding {  get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public string DisplayOrder { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        public string RoleType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }




    }
}
