using HIS.RBAC;
using HIS.System_Administration;
using HIS.SystemConfigurations;
using RabbitManage.EntityFrameworkCore;
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
        Task<APIResDto> AddNature(NaturePatientsDTO nature);
        /// <summary>
        /// 异步获取病人性质
        /// </summary>
        /// <returns></returns>
        Task<APIResDto> GetNaturePatient();
        /// <summary>
        /// 异步删除病人性质
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<APIResDto> DelNaturePatient(Guid id);
        /// <summary>
        /// 修改病人性质
        /// </summary>
        /// <param name="nature"></param>
        /// <returns></returns>
        Task<APIResDto> UpdateNaturePatient(NaturePatientsDTO nature);

    }
}
