using AutoMapper;
using HIS.RegistrationServices;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
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

        public Task<APIResult<RegistrationDto>> CreateRegistration(RegistrationDto registration)
        {
            throw new System.NotImplementedException();
        }
    }
}
