
using HIS.InpatientRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.Doctors
{
    public interface IDoctorServices : IApplicationService
    {
        Task<APIResult<DoctorDto>> AddDoctor(DoctorDto patient);
        Task<APIResult<List<DoctorDto>>> GetDoctor();
    }
}
