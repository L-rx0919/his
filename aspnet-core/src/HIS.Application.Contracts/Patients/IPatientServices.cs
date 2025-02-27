using RabbitManage.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.Patients
{
    public interface IPatientServices:IApplicationService
    {
        /// <summary>
        /// 创建患者
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Task<APIResult1<PatientDto>> CreatePatient(PatientDto patient);
        
    }
}
