using AutoMapper;
using HIS.HIS.Departments;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpPost("/api/v1/his/inpatientRecord/insertInpatientRecordinfo")]
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
        /// 删除住院记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete("/api/v1/his/inpatientRecord/id")]
        public async Task<APIResult<InpatientRecordDto>> DelInpatientRecord(Guid id)
        {
            try
            {
                await inpatientRecordRepository.DeleteAsync(x => x.Id == id);
                return new APIResult<InpatientRecordDto>()
                {
                    Code = CodeEnum.success,
                    Message = "删除住院记录成功",
                };
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 获取科室
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<APIResult<List<DepartmentDto>>> GetDepartment()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取医生
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<APIResult<List<InpatientRecordDto>>> GetDoctor()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取住院记录
        /// </summary>
        /// <param name="patient_id"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/his/inpatientRecord/patient_id")]
        public async Task<APIResult<List<InpatientRecordDto>>> GetInpatientRecord(Guid? patient_id)
        {
            //根据患者id四表联查
            var inpatientRecords = await inpatientRecordRepository.GetListAsync();
            var patients = await patientRepository.GetListAsync();
            var doctors = await doctorRepository.GetListAsync();
            var departments = await departmentRepository.GetListAsync();

            var result = from a in inpatientRecords
                         join b in patients on a.patient_id equals b.Id
                         join c in doctors on a.doctor_id equals c.Id
                         join d in departments on a.department_id equals d.Id

                         select new InpatientRecordDto
                         {
                             Id = a.Id,
                             patient_id = a.patient_id,
                             patient_name = b.patient_name,
                             admission_date = a.admission_date,
                             discharge_date = a.discharge_date,
                             department_id = a.department_id,
                             department_name = d.name,
                             doctor_id = a.doctor_id,
                             doctor_name = c.name,
                             room_type = a.room_type,
                             admission_reason = a.admission_reason,
                         };
            var list = result.ToList();
            return new APIResult<List<InpatientRecordDto>>()
            {
                Data = list,
                Code = CodeEnum.success,
                Message = "获取住院记录成功"
            };
        }
        /// <summary>
        /// 获取患者
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<APIResult<List<InpatientRecordDto>>> GetPatient()
        {
            throw new NotImplementedException();
        }
    }
}
