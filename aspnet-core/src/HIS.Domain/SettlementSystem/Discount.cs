using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SettlementSystem
{
    /// <summary>
    ///     费用折扣
    /// </summary>
   public class Discount
    {
        /// <summary>
        ///     费用折扣ID
        /// </summary>
        [Key]
        public int discount_id { get; set; }
        /// <summary>
        ///     费用折扣名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        ///     费用折扣比例
        /// </summary>
        public decimal discount_percentage { get; set; }
        /// <summary>
        ///     折扣开始日期
        /// </summary>
        public DateTime valid_from { get; set; }
        /// <summary>
        ///     折扣结束日期
        /// </summary>
        public DateTime valid_until { get; set; }
//        discount_id：折扣ID
//name：折扣名称（如优惠、医保折扣等）
//discount_percentage：折扣比例
//valid_from：折扣开始日期
//valid_until：折扣结束日期
    }
}
