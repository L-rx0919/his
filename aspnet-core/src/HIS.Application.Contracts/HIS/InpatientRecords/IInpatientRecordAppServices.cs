using HIS.HIS.Departments;
using HIS.HIS.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.InpatientRecords
{
    public interface IInpatientRecordAppServices : IApplicationService
    {
        Task<APIResult<InpatientRecordDto>> AddInpatientRecord(InpatientRecordDto patient);
        Task<APIResult<List<InpatientRecordDto>>> GetInpatientRecord(Guid? patient_id);
        Task<APIResult<InpatientRecordDto>> DelInpatientRecord(Guid id);
        Task<APIResult<List<InpatientRecordDto>>> GetDoctor();
        Task<APIResult<List<DepartmentDto>>> GetDepartment();
        Task<APIResult<List<InpatientRecordDto>>> GetPatient();
    }
}
