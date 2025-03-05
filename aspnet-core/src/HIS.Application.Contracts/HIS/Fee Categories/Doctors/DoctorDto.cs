using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.HIS.Doctors
{
    public class DoctorDto
    {
        /// <summary>
        ///     医生姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary>
        public int department_id { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 专科
        /// </summary>
        public string specialty { get; set; }
    }
}
