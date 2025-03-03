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
    }
}
