﻿using AutoMapper;
using HIS.HIS.NaturepatientServices;
using HIS.System_Administration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.Naturepatients
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class NaturepatientsServices : ApplicationService, INaturepatientServices
    {
        /// <summary>
        /// 病人性质仓储
        /// </summary>
        private readonly IRepository<NatureofPatient> natureofPatientRepository;
        /// <summary>
        /// AutoMapper映射器
        /// </summary>
        private readonly IMapper mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="natureofPatientRepository"></param>
        /// <param name="mapper"></param>
        public NaturepatientsServices(IRepository<NatureofPatient> natureofPatientRepository, IMapper mapper)
        {
            this.natureofPatientRepository = natureofPatientRepository;
            this.mapper = mapper;
        }
        /// <summary>
        ///  添加病人性质
        /// </summary>
        /// <param name="nature"></param>
        /// <returns></returns>

        [HttpPost("/api/v1/his/systemconfig/patientCategory/NatureofPatient")]
        public async Task<APIResult<NaturepatientDTO>> CreateNaturepatient(NaturepatientDTO nature)
        {  // 映射DTO到实体
            NatureofPatient entity = ObjectMapper.Map<NaturepatientDTO, NatureofPatient>(nature);

            // 如果映射失败，返回错误
            if (entity == null)
            {
                return new APIResult<NaturepatientDTO>()
                {
                    Code = CodeEnum.error,
                    Message = "添加病人性质记录失败，映射数据为空",
                };
            }

            else 
            {
                // 插入实体数据
                await natureofPatientRepository.InsertAsync(entity);
                // 返回成功结果
                return new APIResult<NaturepatientDTO>()
                {
                    Code = CodeEnum.success,
                    Message = "添加病人性质记录成功",
                  
                };
            }
        }


        /// <summary>
        /// 查询病人性质
        /// </summary>
        /// <returns>病人性质列表</returns>
        [HttpGet("/api/v1/his/systemconfig/patientCategory/NatureofPatientList")]
   
        public async Task<APIResult<List<NaturepatientDTO>>> GetNatyrePatiient()
        {
            var natureOfPatients = await natureofPatientRepository.GetListAsync();
            var list = ObjectMapper.Map<List<NatureofPatient>, List<NaturepatientDTO>>(natureOfPatients);
            return new APIResult<List<NaturepatientDTO>>
            {
                Code = CodeEnum.success,
                Message = "获取查询病人性质",
                Data = list
            };
        }


            /// <summary>
            /// 删除病人性质
            /// </summary>
            [HttpDelete("/api/v1/his/systemconfig/patientCategory/NatureofPatientDel/{id}")]
            public async Task<ResultDto> DelNaturepatient(Guid id, int IsDeleted)
            {
                // 查找病人性质记录
                var natureofPatient = await natureofPatientRepository.FindAsync(x=>x.Id==id);
                if (natureofPatient == null)
                {
                    return ResultDto.Fail("未找到病人性质记录");
                }     
                // 设置删除标志
                natureofPatient.IsDeleted = IsDeleted == 1;
                // 更新记录
                await natureofPatientRepository.UpdateAsync(natureofPatient);
                return ResultDto.OK(null, "删除病人性质记录成功");
            }

        
    }
}
