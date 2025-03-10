using AutoMapper;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using HIS.HIS.FinancialInvoicesServices;
using HIS.System_Administration;
using HIS.SystemDicServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.FinancialInvoicests
{
    /// <summary>
    /// 财务发票服务
    /// </summary>
    /// 

    [ApiExplorerSettings(GroupName = "v1")]
    public class FinancialInvoicesServices : ApplicationService, IFinancialInvoicesServices
    {
        private readonly IRepository<FinancialInvoices> FinancialInvoicesRepository; // 财务发票仓储
        /// <summary>
        /// AutoMapper映射器
        /// </summary>
        private readonly IMapper mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="financialInvoicesRepository"></param>
        /// <param name="mapper"></param>
        public FinancialInvoicesServices(IRepository<FinancialInvoices> financialInvoicesRepository, IMapper mapper)
        {
            FinancialInvoicesRepository = financialInvoicesRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// 添加发票信息
        /// </summary>
        /// <param name="financial"></param>
        /// <returns></returns>
        [HttpPost("CreateAsync")]
        public async Task<APIResult<FinancialInvoicesDTO>> CreateAsync(FinancialInvoicesDTO financial)
        {
            FinancialInvoices entity = ObjectMapper.Map<FinancialInvoicesDTO, FinancialInvoices>(financial);
            if (entity == null)
            {
                return new APIResult<FinancialInvoicesDTO>()
                {
                    Code = CodeEnum.error,
                    Message = "添加发票信息错误"
                };
            }
            else
            {
                await FinancialInvoicesRepository.InsertAsync(entity);
                return new APIResult<FinancialInvoicesDTO>()
                {
                    Code = CodeEnum.success,
                    Message = "添加发票信息成功",

                };
            }
        }

        /// <summary>
        ///  查询分页显示
        /// </summary>
        /// <param name="paramsDto"></param>
        /// <param name="FinancialInvoicesinitial"></param>
        /// <returns></returns>
        [HttpPost("GetListAsync")]
        public async Task<APIResult<PageResultDto<FinancialInvoicesDTO>>> GetListAsync([FromQuery]PageParamsDto paramsDto, string FinancialInvoicesinitial)
        {

            var list = await FinancialInvoicesRepository.GetListAsync();
            var res = ObjectMapper.Map<List<FinancialInvoices>, List<FinancialInvoicesDTO>>(list);
            if (!string.IsNullOrEmpty(FinancialInvoicesinitial))
            {
                res = res.Where(x => x.FinancialInvoicesinitial.Contains(FinancialInvoicesinitial, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            PageResultDto<FinancialInvoicesDTO> page = new PageResultDto<FinancialInvoicesDTO>()
            {
                Total = res.Count,
                List = res.Skip((paramsDto.PageNum - 1) * paramsDto.PageSize).Take(paramsDto.PageSize).ToList()
            };
            return new APIResult<PageResultDto<FinancialInvoicesDTO>>()
            {
                Code = CodeEnum.success,
                Message = "获取发票信息成功",
                Data = page
            };


        }

    }

}








