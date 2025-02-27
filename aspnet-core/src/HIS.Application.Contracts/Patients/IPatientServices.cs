using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.Patients
{
    public interface IPatientServices:IApplicationService
    {
       Task<APIResult<PatientDto>> CreatePatient(PatientDto patient);
    }
}
