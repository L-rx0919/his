using AutoMapper;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.Departments
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class DepartmentServices : ApplicationService, IDepartmentServices
    {
        /// <summary>
        /// 科室仓储
        /// </summary>
        private readonly IRepository<Department> DepartmentRepository;
        /// <summary>
        /// 门诊类型仓储
        /// </summary>
        private readonly IRepository<Clinic_type> ClinicTypeRepository;
        /// <summary>
        /// 科室门诊类型仓储
        /// </summary>
        private readonly IRepository<Clinic_type_department> ClinicTypeDepartmentRepository;
        /// <summary>
        /// AutoMapper映射器
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="departmentRepository"></param>
        /// <param name="clinicTypeRepository"></param>
        /// <param name="clinicTypeDepartmentRepository"></param>
        /// <param name="mapper"></param>
        public DepartmentServices(IRepository<Department> departmentRepository, IRepository<Clinic_type> clinicTypeRepository, IRepository<Clinic_type_department> clinicTypeDepartmentRepository, IMapper mapper)
        {
            DepartmentRepository = departmentRepository;
            ClinicTypeRepository = clinicTypeRepository;
            ClinicTypeDepartmentRepository = clinicTypeDepartmentRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 添加科室
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("api/InsertDepartment")]
        public async Task<APIResult<DepartmentDto>> CreateAsync(DepartmentDto input)
        {
            var department = ObjectMapper.Map<DepartmentDto, Department>(input);
            var departmentName = await DepartmentRepository.FirstOrDefaultAsync(x => x.name == input.name);
            if (departmentName != null)
            {
                return new APIResult<DepartmentDto>()
                {
                    Code = CodeEnum.error,
                    Message = "科室名称重复"
                };
            }
            await DepartmentRepository.InsertAsync(department);
            return new APIResult<DepartmentDto>()
            {
                Code = CodeEnum.success,
                Message = "添加成功",
            };
        }
        /// <summary>
        /// 根据门诊类型ID获取科室信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("api/ShowDepartment")]
        public async Task<APIResult<DepartmentDto>> GetDepartmentByIdAsync(Guid id)
        {
            var clinicTypeDepartment = await ClinicTypeDepartmentRepository.FirstOrDefaultAsync(x => x.clinic_type_id == id);
            if (clinicTypeDepartment == null)
            {
                return new APIResult<DepartmentDto>()
                {
                    Code = CodeEnum.error,
                    Message = "未找到科室信息"
                };
            }

            var department = await DepartmentRepository.FirstOrDefaultAsync(x => x.Id == clinicTypeDepartment.department_id);
            if (department == null)
            {
                return new APIResult<DepartmentDto>()
                {
                    Code = CodeEnum.success,
                    Message = "获取成功",
                    Data = _mapper.Map<Department, DepartmentDto>(department)
                };
            }

            return new APIResult<DepartmentDto>()
            {
                Code = CodeEnum.success,
                Message = "获取成功",
                Data = _mapper.Map<Department, DepartmentDto>(department)
            };
        }
    }
}
