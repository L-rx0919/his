using AutoMapper;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.Patients
{

    [ApiExplorerSettings(GroupName = "v1" )]
    /// <summary>
    /// 患者服务
    /// </summary>

    public class PatientServer :ApplicationService, IPatientServer
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
        public PatientServer(IRepository<Patient> patientRepository, IMapper mapper = null)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// 添加患者
        /// </summary>
        /// <param name="patient"> 患者信息 </param>
        /// <returns> APIResult </returns>
        [HttpPost("api/patients")]
        public async Task<APIResult<PatientDto>> CreatePatient(PatientDto patient)
        {
           Patient entity = ObjectMapper.Map<PatientDto, Patient>(patient);
            await _patientRepository.InsertAsync(entity);

            //判断 用户是否存在
            if (entity == null)
            {
                return new APIResult<PatientDto>()
                {
                    Code = CodeEnum.error,
                    Message = "添加患者失败"
                };
            }
            ////判断名称 是否重复
            //var patientName = await _patientRepository.AllAsync(x => x.patient_name == patient.patient_name);
            //if (patientName!= null)
            //{
            //    return new APIResult<PatientDto>()
            //    {
            //        Code = CodeEnum.error,
            //        Message = "患者名称重复"
            //    };
            //}   
            return new APIResult<PatientDto>()
            {
                Code = 0,
                Message = "添加患者成功",
                Data = _mapper.Map<Patient, PatientDto>(entity)
            };
        }
    }

}






