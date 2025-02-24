﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.SettlementSystem
{
    /// <summary>
    /// 科室
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 科室ID
        /// </summary>
        [Key]
        public int department_id { get; set; }
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
    }
}
//department_id：科室ID
//name：科室名称
//location：科室位置
//phone：联系电话
//department_type：科室类型（如内科、外科、急诊等）