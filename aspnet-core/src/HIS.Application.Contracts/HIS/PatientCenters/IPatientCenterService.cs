using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.PatientCenters
{
    public interface IPatientCenterService : IApplicationService
    {
        Task<APIResult<List<PatientCenterDto>>> GetPatients(string patientName);
        Task<APIResult<List<ChargingModuleDto>>> GetChargingModule(string id);
    }
}
