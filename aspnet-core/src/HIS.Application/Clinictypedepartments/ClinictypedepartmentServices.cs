using AutoMapper;
using HIS.Clinic_type_departments;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.Clinictypedepartments
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class ClinictypedepartmentServices: ApplicationService,IClinic_type_departmentServices
    {
        /// <summary>
        /// 门诊类型与科室关联仓储
        /// </summary>
        private readonly IRepository<Clinic_type_department> _clinic_type_departmentRepository;
        /// <summary>
        /// AutoMapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clinic_type_departmentRepository"></param>
        /// <param name="mapper"></param>
        public ClinictypedepartmentServices(IRepository<Clinic_type_department> clinic_type_departmentRepository, IMapper mapper)
        {
            _clinic_type_departmentRepository = clinic_type_departmentRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// 添加门诊类型与科室关联
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("api/ClinicTypeDepartment")]
        public async Task<APIResult<Clinic_type_departmentDto>> AddClinicTypeDepartment(Clinic_type_departmentDto input)
        {
            var clinic_type_department = _mapper.Map<Clinic_type_department>(input);
            await _clinic_type_departmentRepository.InsertAsync(clinic_type_department);
            return new APIResult<Clinic_type_departmentDto>
            {
                Code =0,
                Data = input,
                Message = "添加成功"
            };
        }

    }
}
