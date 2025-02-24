using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SettlementSystem
{
    /// <summary>
    /// 收费项目表
    /// </summary>
  public  class FeeItem
    {
        /// <summary>
        ///      费用项目ID
        /// </summary>
        [Key]
        public int item_id { get; set; }
        /// <summary>
        ///      项目名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        ///      单价
        /// </summary>  
        public decimal price { get; set; }
        /// <summary>
        ///      费用类别
        /// </summary>
        public string category { get; set; }
        /// <summary>
        ///      费用描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        ///      是否可以报销
        /// </summary>
        public bool is_refundable { get; set; }
    }
//    item_id：费用项目ID
//name：项目名称（如药品费、检查费等）
//price：单价
//category：费用类别（如诊疗、药品、检查等）
//description：费用描述
//is_refundable：是否可以报销
}
