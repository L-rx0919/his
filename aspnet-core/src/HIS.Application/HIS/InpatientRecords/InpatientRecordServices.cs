using AutoMapper;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.InpatientRecords
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class InpatientRecordServices : ApplicationService, IInpatientRecordAppServices
    {
        private readonly IRepository<InpatientRecord> inpatientRecordRepository;
        private readonly IRepository<Patient> patientRepository;
        private readonly IRepository<Doctor> doctorRepository;
        private readonly IRepository<Department> departmentRepository;
        /// <summary>
        /// 映射器
        /// </summary>
        private readonly IMapper _mapper;
        public InpatientRecordServices(IRepository<InpatientRecord> inpatientRecordRepository, IMapper _mapper, IRepository<Patient> patientRepository, IRepository<Doctor> doctorRepository, IRepository<Department> departmentRepository)
        {
            this.inpatientRecordRepository = inpatientRecordRepository;
            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;
            this.departmentRepository = departmentRepository;
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
        /// 批量删除住院记录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete("api/DelInpatientRecord")]
        public async Task<APIResult<InpatientRecordDto>> DelInpatientRecord(Guid Id)
        {
            //根据Id删除住院记录
            var entity = await inpatientRecordRepository.FirstOrDefaultAsync(x => x.Id == Id);
            return new APIResult<InpatientRecordDto>()
            {
                Code = 0,
                Message = "删除住院记录成功",
            };


        }

        /// <summary>
        /// 获取住院记录
        /// </summary>
        /// <param name="patient_id"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/his/inpatientRecord/page")]
        public async Task<APIResult<InpatientRecordDto>> GetInpatientRecord(Guid patient_id)
        {
            //根据患者id四表联查
            var entity = await inpatientRecordRepository.FirstOrDefaultAsync(x => x.patient_id == patient_id);
            var list = ObjectMapper.Map<InpatientRecord, InpatientRecordDto>(entity);
            if (entity == null)
            {
                return new APIResult<InpatientRecordDto>()
                {

                    Code = CodeEnum.error,
                    Message = "获取住院记录失败",
                };
            }
            else
            {
                return new APIResult<InpatientRecordDto>()
                {
                    Data = list,
                    Code = CodeEnum.success,
                    Message = "获取住院记录成功",
                };
            }


        }


    }
}
