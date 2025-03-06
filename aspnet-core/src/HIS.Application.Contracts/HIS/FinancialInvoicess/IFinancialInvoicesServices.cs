using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.HIS.FinancialInvoicesServices
{
    /// <summary>
    /// 发票配置接口
    /// </summary>
    public interface IFinancialInvoicesServices : IApplicationService
    {/// <summary>
    /// 添加发票配置
    /// </summary>
    /// <param name="financial"></param>
    /// <returns></returns>
        Task<APIResult<FinancialInvoicesDTO>> CreateAsync(FinancialInvoicesDTO financial);
    }
}
