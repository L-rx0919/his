using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.Fee_Categories
{
    public interface IFee_Category : IApplicationService
    {
        Task<APIResult<Fee_CategoryDto>> AddFee_Category(Fee_CategoryDto patient);
        Task<APIResult<List<Fee_CategoryDto>>> GetFee_Category();
    }
}
