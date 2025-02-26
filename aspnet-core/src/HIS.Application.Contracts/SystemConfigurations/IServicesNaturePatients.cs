using HIS.RBAC;
using HIS.SystemConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.SystemConfiguration
{
    /// <summary>
    /// 病人性质接口
    /// </summary>
    public interface IServicesNaturePatients:IApplicationService
    {
        /// <summary>
        /// 异步添加病人性质
        /// </summary>
        /// <param name="Nature"></param>
        /// <returns></returns>
        Task<APIResult<NaturePatientsDTO>> AddNature(NaturePatientsDTO nature);

    }
}
