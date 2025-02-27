using AutoMapper;
using HIS.Patients;
using HIS.SettlementSystem;
using HIS.System_Administration;
using HIS.SystemConfiguration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace HIS.SystemConfigurations
{
    [ApiExplorerSettings(GroupName ="v1")]
    /// <summary>
    /// 病人性质
    /// </summary>
    public class NatureServices : ApplicationService, IServicesNaturePatients
    {
      private readonly IRepository<NatureofPatient> NatureofPatientRepository;
        /// <summary>
        /// 映射器
        /// </summary>
        private readonly IMapper mapper;

        public NatureServices(IRepository<NatureofPatient> natureofPatientRepository, IMapper mapper)
        {
            NatureofPatientRepository = natureofPatientRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// 异步添加病人性质
        /// </summary>
        /// <param name="nature"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// 
        [HttpPost("api/AddNatures")]
        public async Task<APIResult<NaturePatientsDTO>> AddNature(NaturePatientsDTO nature)
        {



            NatureofPatient entity = ObjectMapper.Map<NaturePatientsDTO, NatureofPatient>(nature);

            var NatureName = await NatureofPatientRepository.AllAsync(x => x.NatureofPatientName == nature.NatureofPatientName);
            if (NatureName == false)
            {
                return new APIResult<NaturePatientsDTO>()
                {
                    Code = CodeEnum.error,
                    Message = "病人性质名称重复"
                };
            }
            else
            {
                await NatureofPatientRepository.InsertAsync(entity);
                return new APIResult<NaturePatientsDTO>()
                {
                    Code = 0,
                    Message = "添加病人性质成功",
                   
                };
            }




        }
    }
}
