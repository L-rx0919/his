using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.Chargemodules
{
    public interface IServicesChargemodules : IApplicationService
    {
        /// <summary>
        /// 添加收费模块
        /// </summary>
        /// <param name="chargemodules"></param>
        /// <returns></returns>
        Task<APIResult<ChargemodulesDTO>> AddChargemodules(ChargemodulesDTO chargemodules);
        /// <summary>
        /// 联合查询
        /// </summary>
        /// <returns></returns>
        Task<APIResult<List<GetChargemodulesByDepartmentDto>>> GetChargemodulesByDepartment(string templateName = null);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<APIResult<GetChargemodulesByDepartmentDto>> DeleteChargemodules(Guid id);




    }
}
