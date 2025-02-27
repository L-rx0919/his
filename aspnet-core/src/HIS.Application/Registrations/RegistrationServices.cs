using AutoMapper;
using HIS.RegistrationServices;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.Registrations
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class RegistrationServices : ApplicationService, IRegistrationServices
    {
        /// <summary>
        /// 挂号仓储
        /// </summary>
        private readonly IRepository<Registration> _registrationRepository;
        /// <summary>
        /// AutoMapper映射器
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="registrationRepository"></param>
        /// <param name="mapper"></param>
        public RegistrationServices(IRepository<Registration> registrationRepository, IMapper mapper)
        {
            _registrationRepository = registrationRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// 添加挂号
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public async Task<APIResult<RegistrationDto>> CreateRegistration(RegistrationDto registration)
        {
            Registration entity = ObjectMapper.Map<RegistrationDto, Registration>(registration);
            await _registrationRepository.InsertAsync(entity);
            return new APIResult<RegistrationDto>()
            {
                Code = 0,
                Message = "添加挂号成功",
                Data = ObjectMapper.Map<Registration, RegistrationDto>(entity)
            };
        }
        /// <summary>
        /// 查寻当日挂号信息
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<APIResult<RegistrationDto>> GetRegistrationByDate(DateTime date)
        {
            date = DateTime.Now;
            var registration = await _registrationRepository.FirstOrDefaultAsync(x => x.RegistrationTime.Date == date.Date);
            if (registration == null)
            {
                return new APIResult<RegistrationDto>()
                {
                    Code = CodeEnum.notfound,
                    Message = "未找到当日挂号信息"
                };
            }
            return new APIResult<RegistrationDto>()
            {
                Code = 0,
                Message = "查询成功",
                Data = ObjectMapper.Map<Registration, RegistrationDto>(registration)
            };
        }
    }
}
