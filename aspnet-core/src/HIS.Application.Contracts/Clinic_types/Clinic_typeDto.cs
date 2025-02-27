using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.Clinic_types
{
    public class Clinic_typeDto:FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 门诊类型名称（如“普通门诊”“专家门诊”）
        /// </summary>
        public string Clinic_type_name { get; set; }
        /// <summary>
        /// 门诊类型描述（如“针对常见病的常规诊疗”）
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 基础挂号费（可动态调整，如普通门诊30元，专家门诊100元）
        /// </summary>
        public decimal Base_fee { get; set; }
        /// <summary>
        /// 是否为急诊
        /// </summary>
        public bool Is_emergency { get; set; }
        /// <summary>
        /// 是否开放挂号（用于临时关闭某类门诊）
        /// </summary>
        public bool Is_available { get; set; }
        /// <summary>
        /// 单日最大挂号量（防止资源过载）
        /// </summary>
        public int Max_daily_capacity { get; set; }
        /// <summary>
        /// 接诊医生最低职称（如专家门诊需“副主任医师”以上）
        /// </summary>
        public string Required_doctor_title { get; set; }
    }
}
