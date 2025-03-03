using AutoMapper;
using HIS.System_Administration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.Chargemodules
{

    [ApiExplorerSettings(GroupName = "v1")]
    public class ChargemodulesServices(IRepository<Chargingmodule> chargemodulesRepository, IMapper mapper) : ApplicationService, IServicesChargemodules
    {
        private readonly IRepository<Chargingmodule> chargemodulesRepository = chargemodulesRepository;
        private readonly IMapper mapper = mapper;

        /// <summary>
        /// 添加收费模块
        ///</summary>
        [HttpPost("api/AddChargemodules")]
        public async Task<ResultDto> AddChargemodules(ChargemodulesDTO chargemodules)
        {
            var existingModule = await chargemodulesRepository.FirstOrDefaultAsync(x => x.TemplateName == chargemodules.TemplateName);

            // 如果模板名称不存在，则插入新数据
            if (existingModule == null)
            {
                // 映射 DTO 到实体
                var entity = mapper.Map<Chargingmodule>(chargemodules);

                // 插入数据
                await chargemodulesRepository.InsertAsync(entity);

                // 返回成功
                return ResultDto.OK(data: entity);
            }
            else
            {
                // 如果模板名称已存在，返回失败结果
                return ResultDto.Fail("模板名称已存在");
            }
        }

        /// <summary>
        /// 获取收费
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/GetChargemodules")]
        public async Task<ResultDto> GetChargemodules()
        {
            var list = await chargemodulesRepository.GetListAsync();
            return ResultDto.OK(data: list);
        }

        ///<summary>
        ///删除收费
        /// </summary>
        [HttpDelete("api/DelChargemodules")]
        public async Task<ResultDto> DelChargemodules(Guid id)
        {
            var list = await chargemodulesRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (list != null)
            {
                await chargemodulesRepository.DeleteAsync(list);
                return ResultDto.OK();
            }
            else
            {
                return ResultDto.Fail("删除失败");
            }
        }
    }
}
