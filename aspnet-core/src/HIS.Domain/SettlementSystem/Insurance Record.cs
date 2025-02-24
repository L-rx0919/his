using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SettlementSystem
{
    /// <summary>
    ///  医保记录
    /// </summary>
    public class Insurance_Record
    {
        /// <summary>
        /// 医保记录ID
        /// </summary>
        [Key]
        public int insurance_id { get; set; }
        /// <summary>
        /// 病人ID
        /// </summary>
        public int patient_id { get; set; }
        /// <summary>
        /// 医保类型
        /// </summary>
        public string insurance_type { get; set; }
        /// <summary>
        /// 医保编号
        /// </summary>  
        public string insurance_number { get; set; }
          
        /// <summary>
        /// 报销比例
        /// </summary>
        public double coverage { get; set; }
        /// <summary>
        /// 医保起始日期
        /// </summary>
        public DateTime start_date { get; set; }
        /// <summary>
        /// 医保结束日期
        /// </summary>
        public DateTime end_date { get; set; }
//        insurance_id：医保记录ID
//patient_id：病人ID（外键）
//insurance_type：医保类型（如城镇职工医保、新农合等）
//insurance_number：医保编号
//coverage：报销比例
//start_date：医保起始日期
//end_date：医保结束日期
    }
}
