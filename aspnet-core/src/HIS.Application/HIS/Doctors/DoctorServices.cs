using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.Doctors
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class DoctorServices : ApplicationService, IDoctorServices
    {
        private readonly IRepository<Doctor> doctorRepository;
        
        public DoctorServices(IRepository<Doctor> doctorRepository)
        {
            this.doctorRepository = doctorRepository;
           
        }
        /// <summary>
        /// 添加医生
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        [HttpPost("api/AddDoctors")]
        public async Task<APIResult<DoctorDto>> AddDoctor(DoctorDto patient)
        {
            Doctor entity = ObjectMapper.Map<DoctorDto, Doctor>(patient);
            if (entity == null)
            {
                return new APIResult<DoctorDto>()
                {
                    Code = CodeEnum.error,
                    Message = "添加医生失败",
                };
            }
            else
            {
                await doctorRepository.InsertAsync(entity);
                return new APIResult<DoctorDto>()
                {
                    Code = 0,
                    Message = "添加医生成功",
                };

            }
        }
        /// <summary>
        /// 获取医生
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("api/GetDoctor")]
        public async Task<APIResult<List<DoctorDto>>> GetDoctor()
        {
            //查询所有医生
            var doctors = await doctorRepository.GetListAsync();
            var list = ObjectMapper.Map<List<Doctor> ,List<DoctorDto>>(doctors);
            return new APIResult<List<DoctorDto>>
            {
                Code = CodeEnum.success,
                Message = "获取医生成功",
                Data = list
            };

        }
    }
}
