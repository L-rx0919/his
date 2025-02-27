using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.Chargingmodules
{
    /// <summary>
    /// 收费模块接口
    /// </summary>
    public interface INewchargingmodule : IApplicationService
    {
        /// <summary>
        /// 异步添加新收费项目
        /// </summary>
        /// <param name="charging"></param>
        /// <returns></returns>
        Task<APIResult<NewchargingmoduleDTO>> AddCharging(NewchargingmoduleDTO charging);
    }
}
