using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.RegistrationServices
{
   public interface IRegistrationServices:IApplicationService
    {
        /// <summary>
        /// 添加挂号
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        Task<APIResult<RegistrationDto>> CreateRegistration(RegistrationDto registration);
        /// <summary>
        /// 查询当日挂号信息
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<APIResult<RegistrationDto>> GetRegistrationByDate(DateTime date);
    }
}
