using AutoMapper;
using HIS.HIS.Clinic_types;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.Clinictypes
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class ClinictypeServices: ApplicationService, IClinic_typeServices
    {
        /// <summary>
        /// 门诊类型仓储
        /// </summary>
        private readonly IRepository<Clinic_type> _clinicTypeRepository;
        /// <summary>
        /// AutoMapper映射器
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clinicTypeRepository"></param>
        /// <param name="mapper"></param>
        public ClinictypeServices(IRepository<Clinic_type> clinicTypeRepository, IMapper mapper)
        {
            _clinicTypeRepository = clinicTypeRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// 查询门诊类型
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet("api/ShowClinictype")]
        public async Task<List<Clinic_typeDto>> GetListAsync()
        {
            var clinicTypes = await _clinicTypeRepository.GetListAsync();
            return _mapper.Map<List<Clinic_type>, List<Clinic_typeDto>>(clinicTypes);
        }
        /// <summary>
        ///  添加门诊类型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("api/InsertClinictype")]
        public async Task<APIResult<Clinic_typeDto>> CreateAsync(Clinic_typeDto input)
        {
            var clinicType = _mapper.Map<Clinic_typeDto, Clinic_type>(input);
            var clinicTypeName = await _clinicTypeRepository.FirstOrDefaultAsync(x => x.Clinic_type_name == input.Clinic_type_name);
            if (clinicTypeName != null)
            {
                return new APIResult<Clinic_typeDto>()
                {
                    Code = CodeEnum.error,
                    Message = "门诊类型名称重复"
                };
            }
            await _clinicTypeRepository.InsertAsync(clinicType);
            return new APIResult<Clinic_typeDto>()
            {
                Code = CodeEnum.success,
                Message = "添加门诊类型成功",
                Data = _mapper.Map<Clinic_type, Clinic_typeDto>(clinicType)
            };
        }
    }
}
