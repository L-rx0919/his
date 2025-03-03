using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.HIS.Insurance_Records
{
    public class Insurance_RecordDto
    {
        /// <summary>
        /// 病人ID
        /// </summary>
        public Guid patient_id { get; set; }
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
    }
}
