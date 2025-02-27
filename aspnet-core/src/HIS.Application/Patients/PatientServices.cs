using AutoMapper;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using RabbitManage.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
                                                                                                                                                                                                                                                                                                      
namespace HIS.Patients
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
        public async Task<APIResult1<PatientDto>> CreatePatient(PatientDto patient)
        {
           Patient entity = ObjectMapper.Map<PatientDto, Patient>(patient);
           

          
            //判断名称 是否重复
            var patientName = await _patientRepository.AllAsync(x => x.patient_name == patient.patient_name);
            if (patientName == false)
            {
                return new APIResult1<PatientDto>()
                {
                    Code = CodeEnum.error,
                    Message = "患者名称重复"
                };
            }
            else
            {
                await _patientRepository.InsertAsync(entity);
                return new APIResult1<PatientDto>()
                {
                    Code = 0,
                    Message = "添加患者成功",

                };
            }
            
        }

        public Task<APIResult> GetNaturePatient()
        {
            throw new System.NotImplementedException();
        }
    }

}






