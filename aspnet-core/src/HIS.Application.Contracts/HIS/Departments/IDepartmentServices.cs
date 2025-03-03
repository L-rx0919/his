using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.Departments
{
    public interface IDepartmentServices : IApplicationService
    {
        /// <summary>
        /// 添加科室
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<APIResult<DepartmentDto>> CreateAsync(DepartmentDto input);
        /// <summary>
        /// 根据门诊类型Id获取科室信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<APIResult<DepartmentDto>> GetDepartmentByIdAsync(Guid id);
    }
}
