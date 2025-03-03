using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.Clinic_type_departments
{
    public interface IClinic_type_departmentServices:IApplicationService
    {
        /// <summary>
        /// 添加门诊类型与科室关联
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<APIResult<Clinic_type_departmentDto>> AddClinicTypeDepartment(Clinic_type_departmentDto input);
    }
}
