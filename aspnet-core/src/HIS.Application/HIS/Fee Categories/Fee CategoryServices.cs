using AutoMapper;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.Fee_Categories
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class Fee_CategoryServices : ApplicationService, IFee_Category
    {
        private readonly IRepository<Fee_Category> fee_CategoryRepository;
        // <summary>
        /// 映射器
        /// </summary>
        private readonly IMapper _mapper;
        public Fee_CategoryServices(IRepository<Fee_Category> fee_CategoryRepository, IMapper _mapper)
        {
            this.fee_CategoryRepository = fee_CategoryRepository;
            this._mapper = _mapper;
        }
        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        [HttpPost("api/AddFee_Category")]
        public async Task<APIResult<Fee_CategoryDto>> AddFee_Category(Fee_CategoryDto patient)
        {
            Fee_Category list = ObjectMapper.Map<Fee_CategoryDto, Fee_Category>(patient);
            await fee_CategoryRepository.InsertAsync(list);
            return new APIResult<Fee_CategoryDto>
            {
                Code = CodeEnum.success,
                Message = "添加费用类别成功",
                Data = patient
            };

        }

        /// <summary>
        /// 获取费用类别
        /// </summary>
        /// <returns></returns>
        [HttpPost("api/GetFee_Category")]
        public async Task<APIResult<List<Fee_CategoryDto>>> GetFee_Category()
        {
            var entity = await fee_CategoryRepository.GetListAsync();
            var list = ObjectMapper.Map<List<Fee_Category>, List<Fee_CategoryDto>>(entity);
            return new APIResult<List<Fee_CategoryDto>>
            {
                Code = CodeEnum.success,
                Message = "获取费用类别成功",
                Data = list
            };

        }
    }
}
