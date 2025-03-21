﻿using HIS.HIS.Departments;
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
        Task<APIResult<InsertInpatientRecordsDto>> AddInpatientRecord(InsertInpatientRecordsDto patient);
        Task<APIResult<PageResultDto<InpatientRecordDto>>> GetInpatientRecord(PageParamsDto paramsDto, Guid? patient_id);
        Task<APIResult<InpatientRecordDto>> DelInpatientRecord(Guid id);
        Task<APIResult<InpatientRecordDto>> UpdateInpatientRecord(InpatientRecordDto patient);

    }
}
