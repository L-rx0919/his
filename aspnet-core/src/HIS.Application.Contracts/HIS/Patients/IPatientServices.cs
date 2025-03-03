using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.Patients
{
    public interface IPatientServices:IApplicationService
    {
        /// <summary>
        /// 添加患者
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Task<APIResult<PatientDto>> CreatePatient(PatientDto patient);
        /// <summary>
        /// 获取所有患者
        /// </summary>
        /// <returns></returns>
        Task<APIResult<List<PatientDto>>> GetPatients(string name, string phone);
    }
}
