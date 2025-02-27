using AutoMapper;
using HIS.Patients;
using HIS.SettlementSystem;
using HIS.System_Administration;
using HIS.SystemConfiguration;
using Microsoft.AspNetCore.Mvc;
using RabbitManage.EntityFrameworkCore;
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
    [ApiExplorerSettings(GroupName = "v1")]
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
        public async Task<APIResult> AddNature(NaturePatientsDTO nature)
        {
            

            var list = await NatureofPatientRepository.FirstOrDefaultAsync(x => x.NatureofPatientName == nature.NatureofPatientName);

            if (list == null)
            {
                // Map the 'nature' object to 'NatureofPatient' entity
                var entity = mapper.Map<NatureofPatient>(nature);

                // Insert the newly mapped 'entity' instead of 'list'
                await NatureofPatientRepository.InsertAsync(entity);

                // Return the inserted entity as a success response
                return APIResult.OK(data: entity);
            }
            else
            {
                // Return failure response if the entity already exists
                return APIResult.Fail("已存在该病人性质");
            }



        }

        /// <summary>
        /// 获取病人性质
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/GetNatures")]
        public async Task<APIResult> GetNaturePatient()
        {
            var list = await NatureofPatientRepository.GetListAsync();
            return APIResult.OK(data: list);
        }


        ///<summary>
        ///删除病人性质
        /// </summary>
        /// 

        [HttpDelete("api/DelNaturePatient")]

       public async Task<APIResult> DelNaturePatient(Guid id)
        {
            var list = await NatureofPatientRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (list != null)
            {
                await NatureofPatientRepository.DeleteAsync(list);
                return APIResult.OK();
            }
            else
            {
                return APIResult.Fail("删除失败");
            }
        }
        ///<summary>
        ///修改病人性质
        /// </summary>
        /// 

        [HttpPut("api/UpdateNaturePatient")]
        public async Task<APIResult> UpdateNaturePatient(NaturePatientsDTO nature)
        {
            var list = await NatureofPatientRepository.FirstOrDefaultAsync(x => x.NatureofPatientName == nature.NatureofPatientName);
            if (list != null)
            {
                list.NatureofPatientName = nature.NatureofPatientName;
                await NatureofPatientRepository.UpdateAsync(list);
                return APIResult.OK();
            }
            else
            {
                return APIResult.Fail("修改失败");
            }
        }
    }
}
