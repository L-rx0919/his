using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.InpatientRecords
{
    public interface IInpatientRecordServer : IApplicationService
    {
        Task<APIResult1<InpatientRecordDto>> AddInpatientRecord(InpatientRecordDto patient);
    }
}
