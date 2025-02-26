using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.Patients
{
    public interface IPatientServer:IApplicationService
    {
       Task<APIResult<PatientDto>> CreatePatient(PatientDto patient);
    }
}
