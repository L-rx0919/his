using AutoMapper;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.Departments
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class DepartmentServices: ApplicationService, IDepartmentServices
    {
        /// <summary>
        /// 科室仓储
        /// </summary>
        private readonly IRepository<Department> DepartmentRepository;
        /// <summary>
        /// AutoMapper映射器
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="departmentRepository"></param>
        /// <param name="mapper"></param>
        public DepartmentServices(IRepository<Department> departmentRepository, IMapper mapper)
        {
            DepartmentRepository = departmentRepository;
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
            var department = _mapper.Map<DepartmentDto, Department>(input);
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
                Data = _mapper.Map<Department, DepartmentDto>(department)
            };
        }
      
    }
}
