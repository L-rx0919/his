using RabbitManage.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.Chargemodules
{
    public interface IServicesChargemodules : IApplicationService
    {
        /// <summary>
        /// 添加收费模块
        /// </summary>
        /// <param name="chargemodules"></param>
        /// <returns></returns>
        Task<APIResult> AddChargemodules(ChargemodulesDTO chargemodules);
        /// <summary>
        /// 获取收费模块
        /// </summary>
        /// <returns></returns>
        Task<APIResult> GetChargemodules();
    }
}
