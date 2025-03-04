using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.Doctors
{
    public interface IDoctorServices : IApplicationService
    {
        Task<APIResult<DoctorDto>> AddDoctor(DoctorDto patient);
        Task<APIResult<List<DoctorDto>>> GetDoctor();
    }
}
