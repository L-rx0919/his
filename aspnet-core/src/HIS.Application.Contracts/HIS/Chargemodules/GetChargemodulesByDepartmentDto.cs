using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.HIS.Chargemodules
{
    public class GetChargemodulesByDepartmentDto
    {
        /// <summary>
        /// 模版名称
        /// </summary>
        public string TemplateName { get; set; }
        public string DepartmentName { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 科室位置
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 科室类型（如内科、外科、急诊等）
        /// </summary>

        public string department_type { get; set; }

       
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
