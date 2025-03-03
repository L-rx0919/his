using HIS.HIS.NaturepatientServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.SystemConfigurations
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
        Task<APIResult<NaturepatientDTO>> AddNature(NaturepatientDTO nature);
        /// <summary>
        /// 获取病人性质
        /// </summary>
        /// <returns></returns>
        Task<APIResult<List<NaturepatientDTO>>> GetNaturePatient();

    }
}
