using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.Departments
{
    public interface IDepartmentServices : IApplicationService
    {
        /// <summary>
        /// 添加科室
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<APIResult<DepartmentDto>> CreateAsync(DepartmentDto input);
    }
}
