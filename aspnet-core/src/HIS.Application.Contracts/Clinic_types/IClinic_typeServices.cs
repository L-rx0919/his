using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.Clinic_types
{
    public interface IClinic_typeServices:IApplicationService
    {
        /// <summary>
        /// 查询门诊类型
        /// </summary>
        /// <returns></returns>
        Task<List<Clinic_typeDto>> GetListAsync();
        /// <summary>
        /// 添加门诊类型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<APIResult<Clinic_typeDto>> CreateAsync(Clinic_typeDto input);

    }
}
