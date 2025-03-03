using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.SettlementSystem
{
    /// <summary>
    /// 门诊类型表
    /// </summary>
    public class Clinic_type: FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 门诊类型名称（如“普通门诊”“专家门诊”）
        /// </summary>
        [StringLength(30)]
        public string Clinic_type_name { get; set; }
        /// <summary>
        /// 门诊类型描述（如“针对常见病的常规诊疗”）
        /// </summary>
        [StringLength(200)]
        public string Description { get; set; }
        /// <summary>
        /// 基础挂号费（可动态调整，如普通门诊30元，专家门诊100元）
        /// </summary>
        [Range(0, 9999999999.99)]
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
        [StringLength(100)]
        public int Max_daily_capacity { get; set; }
        /// <summary>
        /// 接诊医生最低职称（如专家门诊需“副主任医师”以上）
        /// </summary>
        public string Required_doctor_title { get; set; }
    }
}
