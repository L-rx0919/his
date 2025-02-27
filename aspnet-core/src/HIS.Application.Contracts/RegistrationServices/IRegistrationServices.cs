using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.RegistrationServices
{
   public interface IRegistrationServices:IApplicationService
    {
        // 添加挂号
        Task<APIResult<RegistrationDto>> CreateRegistration(RegistrationDto registration);
    }
}
