using AutoMapper;
using HIS.System_Administration;
using HIS.SystemConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitManage.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.Chargemodules
{

    [ApiExplorerSettings(GroupName = "v1")]
    public class ChargemodulesServices : ApplicationService, IServicesChargemodules
    {
        private readonly IRepository<Chargingmodule> chargemodulesRepository;

        private readonly IMapper mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="chargemodulesRepository"></param>
        public ChargemodulesServices(IRepository<Chargingmodule> chargemodulesRepository, IMapper mapper)
        {
            this.chargemodulesRepository = chargemodulesRepository;
            this.mapper = mapper;
        }


        /// <summary>
        /// 添加收费模块
        ///</summary>
        [HttpPost("api/AddChargemodules")]
        public async Task<APIResDto> AddChargemodules(ChargemodulesDTO chargemodules)
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
                return APIResDto.OK(data: entity);
            }
            else
            {
                // 如果模板名称已存在，返回失败结果
                return APIResDto.Fail("模板名称已存在");
            }
            
        }



        /// <summary>
        /// 获取病人性质
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/GetChargemodules")]
        public async Task<APIResDto> GetChargemodules()
        {
            var list = await chargemodulesRepository.GetListAsync();
            return APIResDto.OK(data: list);
        }

        ///<summary>
        ///删除病人性质
        /// </summary>
        /// 

        [HttpDelete("api/DelChargemodules")]

        public async Task<APIResDto> DelChargemodules(Guid id)
        {
            var list = await chargemodulesRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (list != null)
            {
                await chargemodulesRepository.DeleteAsync(list);
                return APIResDto.OK();
            }
            else
            {
                return APIResDto.Fail("删除失败");
            }
        }
    }
}
