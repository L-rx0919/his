using AutoMapper;
using HIS.Patients;
using HIS.RBAC;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.InpatientRecords
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class InpatientRecordServer : ApplicationService, IInpatientRecordServer
    {
        private readonly IRepository<InpatientRecord> inpatientRecordRepository;
        /// <summary>
        /// 映射器
        /// </summary>
        private readonly IMapper _mapper;
        public InpatientRecordServer(IRepository<InpatientRecord> inpatientRecordRepository, IMapper mapper = null)
        {
            this.inpatientRecordRepository = inpatientRecordRepository;
            this._mapper = mapper;
        }
        [HttpPost("api/InpatientRecords")]
        public async Task<APIResult1<InpatientRecordDto>> AddInpatientRecord(InpatientRecordDto patient)
        {
            InpatientRecord entity = ObjectMapper.Map<InpatientRecordDto, InpatientRecord>(patient);

            return new APIResult1<InpatientRecordDto>()
            {
                Code = 0,
                Message = "添加住院记录成功",

            };
        }
    }
}
