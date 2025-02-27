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
using Volo.Abp.ObjectMapping;

namespace HIS.InpatientRecords
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class InpatientRecordServices : ApplicationService, IInpatientRecordAppServices
    {
        private readonly IRepository<InpatientRecord> inpatientRecordRepository;
        /// <summary>
        /// 映射器
        /// </summary>
        private readonly IMapper _mapper;
        public InpatientRecordServices(IRepository<InpatientRecord> inpatientRecordRepository, IMapper _mapper)
        {
            this.inpatientRecordRepository = inpatientRecordRepository;
            this._mapper = _mapper;
        }
        /// <summary>
        /// 添加住院记录
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        [HttpPost("api/AddInpatientRecords")]
        public async Task<APIResult<InpatientRecordDto>> AddInpatientRecord(InpatientRecordDto patient)
        {
            InpatientRecord entity = ObjectMapper.Map<InpatientRecordDto, InpatientRecord>(patient);
            if (entity == null)
            {
                return new APIResult<InpatientRecordDto>()
                {
                    Code = CodeEnum.success,
                    Message = "添加住院记录失败",
                };
            }
            else
            {
                await inpatientRecordRepository.InsertAsync(entity);
                return new APIResult<InpatientRecordDto>()
                {
                    Code = 0,
                    Message = "添加住院记录成功",
                };
            }
        }
        /// <summary>
        /// 获取住院记录
        /// </summary>
        /// <param name="patient_id"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/auth/GetInpatientRecords")]
        public async Task<APIResult<InpatientRecordDto>> GetInpatientRecord(Guid patient_id)
        {
            //根据患者Id 查询住院记录
            var entity = await inpatientRecordRepository.FirstOrDefaultAsync(x => x.patient_id == patient_id);
            var list = ObjectMapper.Map<InpatientRecord, InpatientRecordDto>(entity);
            if (entity == null)
            {
                return new APIResult<InpatientRecordDto>()
                {
                   
                    Code = CodeEnum.success,
                    Message = "获取住院记录失败",
                };
            }       
            else
            {  
                return new APIResult<InpatientRecordDto>()
                {
                    Data = list,
                    Code = 0,
                    Message = "获取住院记录成功",
                };
            }
        }

     
    }
}
