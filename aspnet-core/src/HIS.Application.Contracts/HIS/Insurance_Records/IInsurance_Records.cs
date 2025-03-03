using HIS.HIS.InpatientRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.Insurance_Records
{
    public interface IInsurance_Records : IApplicationService
    {
        Task<APIResult<Insurance_RecordDto>> AddInsurance_Record(InpatientRecordDto patient);
        Task<APIResult<Insurance_RecordDto>> GetInsurance_Record(Guid patient_id);
    }
}
