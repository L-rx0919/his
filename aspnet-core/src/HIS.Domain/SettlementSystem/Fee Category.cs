using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SettlementSystem
{
    /// <summary>
    /// 费用类别
    /// </summary>
    public class Fee_Category
    {
        /// <summary>
        /// 费用类别ID
        /// </summary>
        [Key]
        public int category_id { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string category_name { get; set; }
//        category_id：费用类别ID
//category_name：类别名称（如门诊、住院、检查、药品等）
    }
}
