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
        Task<APIResult<InpatientRecordDto>> GetInpatientRecord(Guid patient_id);
        Task<APIResult<InpatientRecordDto>> DelInpatientRecord(Guid Id);
        

    }
}
