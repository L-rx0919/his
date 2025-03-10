using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.NaturepatientServices
{
    /// <summary>
    /// 病人性质服务接口
    /// </summary>
    public interface INaturepatientServices : IApplicationService
    {
        /// <summary>
        /// 添加病人性质
        /// </summary>
        /// <param name="naturepatients"></param>
        /// <returns></returns>
        Task<APIResult<NaturepatientDTO>> CreateNaturepatient(NaturepatientDTO nature);
        /// <summary>
        /// 获取病人性质
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<APIResult<List<NaturepatientDTO>>> GetNatyrePatiient();
        /// <summary>
        /// 删除病人性质
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResultDto> DelNaturepatient(Guid id, int IsDeleted);
    }
}
