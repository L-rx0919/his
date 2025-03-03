using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS.HIS.RegistrationServices
{
    public class RegistrationDto : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public int Patientid { get; set; }
        /// <summary>
        /// 医生ID
        /// </summary>
        public int DoctorId { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// 挂号时间
        /// </summary>
        public DateTime RegistrationTime { get; set; }
        /// <summary>
        /// 就诊日期
        /// </summary>
        public DateTime VisitDate { get; set; }
        /// <summary>
        /// 挂号状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 挂号费用
        /// </summary>
        public string Fee { get; set; }
    }
}
