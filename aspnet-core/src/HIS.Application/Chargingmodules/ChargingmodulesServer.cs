using HIS.Chargingmodules;
using HIS.SettlementSystem;
using HIS.System_Administration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;


namespace HIS.Chargingmodules
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class ChargingmodulesServer : ApplicationService, INewchargingmodule
    {
        /// <summary>
        /// 收费模块仓储
        /// </summary>
        private readonly IRepository<Chargingmodule> chargingRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="chargingRepository"></param>
        public ChargingmodulesServer(IRepository<Chargingmodule> chargingRepository)
        {
            this.chargingRepository = chargingRepository;
        }
        /// <summary>
        /// 异步添加新收费项目
        /// </summary>
        /// <param name="charging"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// 
        [HttpPost("api/AddCharging")]
        public async Task<APIResult<NewchargingmoduleDTO>> AddCharging(NewchargingmoduleDTO charging)
        {
            Chargingmodule entity = ObjectMapper.Map<NewchargingmoduleDTO, Chargingmodule>(charging);
            var patientName = await chargingRepository.AllAsync(x => x.TemplateName == charging.TemplateName);

            if (patientName == false)
            {
                return new APIResult<NewchargingmoduleDTO>()
                {
                    Code = CodeEnum.error,
                    Message = "模版名称重复"
                };
            }
            else
            {
                await chargingRepository.InsertAsync(entity);
                return new APIResult<NewchargingmoduleDTO>()
                {
                    Code = 0,
                    Message = "添加收费项目成功",
                    Data = charging
                };
            }
        }

       
      
    }
}
