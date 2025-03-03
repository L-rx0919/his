using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.SystemServices
{
    public interface ISystemUserServices : IApplicationService
    {
        Task<APIResult<int>> InitDataAsync();
    }
}
