using AutoMapper;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.Patients
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class PatientServices :ApplicationService, IPatientServices
    {
        /// <summary>
        ///  patients仓储
        /// </summary>
        private readonly IRepository<Patient> _patientRepository;
        /// <summary>
        /// 映射器
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patientRepository"></param>
        /// <param name="mapper"></param>
        public PatientServices(IRepository<Patient> patientRepository, IMapper mapper = null)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// 添加患者
        /// </summary>
        /// <param name="patient"> 患者信息 </param>
        /// <returns> APIResult </returns>
        [HttpPost("api/InsertPatient")]
        public async Task<APIResult<PatientDto>> CreatePatient(PatientDto patient)
        {
           Patient entity = ObjectMapper.Map<PatientDto, Patient>(patient);
           

          
            //判断名称 是否重复
            var patientName = await _patientRepository.AllAsync(x => x.patient_name == patient.patient_name);
            if (patientName == true)
            {
                return new APIResult<PatientDto>()
                {
                    Code = CodeEnum.error,
                    Message = "患者名称重复"
                };
            }
            else
            {
                await _patientRepository.InsertAsync(entity);
                return new APIResult<PatientDto>()
                {
                    Code = 0,
                    Message = "添加患者成功",

                };
            }
            
        }

        /// <summary>
        /// 查询所有患者
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/his/patient/page")]
        public async Task<APIResult<List<PatientDto>>> GetPatients(string name, string phone)
        {
            var list = await _patientRepository.GetListAsync();
            var result = ObjectMapper.Map<List<Patient>, List<PatientDto>>(list);
            if (!string.IsNullOrEmpty(name)) 
            {
                result = result.Where(x => x.patient_name.Contains(name)).ToList();
            }
            if (!string.IsNullOrEmpty(phone)) 
            {
                result = result.Where(x => x.patient_contact== phone).ToList();
            }
            return new APIResult<List<PatientDto>>()
            {
                Code = CodeEnum.success,
                Message = "查询成功",
                Data =result
            };
        }
    }
}






