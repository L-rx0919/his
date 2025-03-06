using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using HIS.SettlementSystem;
using HIS.System_Administration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.Chargemodules
{

    [ApiExplorerSettings(GroupName = "v1")]
    public class ChargemodulesServices : ApplicationService, IServicesChargemodules
    {
        private IRepository<Department> departmentRepository;
        private readonly IRepository<Chargingmodule> chargemodulesRepository;
        private readonly IMapper mapper;

        public ChargemodulesServices(IRepository<Department> departmentRepository, IRepository<Chargingmodule> chargemodulesRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.chargemodulesRepository = chargemodulesRepository;
            this.mapper = mapper;
        }




        /// <summary>
        /// 添加收费模块
        ///</summary>
        [HttpPost("/api/v1/his/systemconfig/chargingmodule/chargingPatient")]
        public async Task<APIResult<ChargemodulesDTO>> AddChargemodules(ChargemodulesDTO chargemodules)
        {
            Chargingmodule chargingmodule = ObjectMapper.Map<ChargemodulesDTO, Chargingmodule>(chargemodules);
            if (chargingmodule == null)
            {
                return new APIResult<ChargemodulesDTO>()
                {
                    Code = CodeEnum.error,
                    Message = "收费模块不能为空"
                };

            }
            else
            {
                await chargemodulesRepository.InsertAsync(chargingmodule);
                return new APIResult<ChargemodulesDTO>()
                {
                    Code = CodeEnum.success,
                    Message = "添加收费模块成功",
                   
                };
            }
        }


        /// <summary>
        /// 收费模块表和科室表联查
        /// </summary>    
        /// <returns></returns>
        [HttpGet("/api/v1/his/systemconfig/chargingmodule/chargingList")]
        public async Task<APIResult<List<GetChargemodulesByDepartmentDto>>> GetChargemodulesByDepartment(string templateName = null)
        {
            var chargemodules = await chargemodulesRepository.GetListAsync();
            var departments = await departmentRepository.GetListAsync();
            var list = from c in chargemodules
                       join d in departments on c.DepartmentID equals d.Id
                       select new GetChargemodulesByDepartmentDto
                       {
                           TemplateName = c.TemplateName,
                           DepartmentName = d.name,
                           name = d.name,             
                           location = d.location,
                           phone = d.phone,
                           department_type = d.department_type,
                           Singltreatment = c.Singltreatment,
                           NumberCutions = c.NumberCutions,
                           TypeRehabil = c.TypeRehabil,
                           Parts = c.Parts,
                           Unittime = c.Unittime,
                       };

            // 如果提供了模板名称，则添加条件过滤
            if (!string.IsNullOrEmpty(templateName))
            {
                list = list.Where(x => x.TemplateName.Contains(templateName));
            }
            var result = list.ToList();
            return new APIResult<List<GetChargemodulesByDepartmentDto>>()
            {
                Data = result,
                Code = CodeEnum.success,
                Message = "获取成功"
            };
        }

        /// <summary>
        /// 删除收费模块
        ///</summary>
        [HttpDelete("api/DeleteChargemodules/{id}")]
        public async Task<APIResult<GetChargemodulesByDepartmentDto>> DeleteChargemodules(Guid id)
        {
            try
            {
                await chargemodulesRepository.DeleteAsync(x => x.Id == id);
                return new APIResult<GetChargemodulesByDepartmentDto>()
                {

                    Code = CodeEnum.success,
                    Message = "删除收费模块成功"
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
