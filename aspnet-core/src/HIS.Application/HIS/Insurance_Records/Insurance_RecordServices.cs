using AutoMapper;
using HIS.HIS.InpatientRecords;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.Insurance_Records
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class Insurance_RecordServices : ApplicationService, IInsurance_Records
    {
        private readonly IRepository<Insurance_Record> insurance_RecordRepository;
        /// <summary>
        /// 映射器
        /// </summary>
        private readonly IMapper _mapper;
        public Insurance_RecordServices(IRepository<Insurance_Record> insurance_RecordRepository, IMapper _mapper)
        {
            this.insurance_RecordRepository = insurance_RecordRepository;
            this._mapper = _mapper;
        }
        /// <summary>
        /// 添加医保记录
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("api/AddInsurance_Record")]
        public async Task<APIResult<Insurance_RecordDto>> AddInsurance_Record(InpatientRecordDto patient)
        {
            Insurance_Record entity=ObjectMapper.Map<InpatientRecordDto, Insurance_Record>(patient);
            await insurance_RecordRepository.InsertAsync(entity);
            return new APIResult<Insurance_RecordDto>()
            {
                Code = 0,
                Message = "添加医保记录成功",
            };

        }
        /// <summary>
        /// 获取医保记录
        /// </summary>
        /// <param name="patient_id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("/api/v1/auth/GetInsurance_Record")]
        public async Task<APIResult<Insurance_RecordDto>> GetInsurance_Record(Guid patient_id)
        {
            //根据病人ID获取医保记录
            var entity = await insurance_RecordRepository.FirstOrDefaultAsync(x => x.patient_id == patient_id);
            var list = ObjectMapper.Map<Insurance_Record, Insurance_RecordDto>(entity);
            if (entity == null)
            {
                return new APIResult<Insurance_RecordDto>()
                {

                    Code = CodeEnum.success,
                    Message = "获取医保记录失败",
                };
            }
            else
            {
                return new APIResult<Insurance_RecordDto>()
                {
                    Data = list,
                    Code = 0,
                    Message = "获取医保记录成功",
                };
            }
        }
    }
}
