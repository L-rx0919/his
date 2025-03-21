﻿using AutoMapper;
using CSRedis;
using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.Patients
{
    

    [ApiExplorerSettings(GroupName = "v1")]
    public class PatientServices : ApplicationService, IPatientServices
    {
        /// <summary>
        ///  patients仓储
        /// </summary>
        private readonly IRepository<Patient> _patientRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly CSRedisClient _cSRedisClient;
        //private readonly 

        /// <summary>
        /// 一卡通信息仓储
        /// </summary>
        private readonly IRepository<Patient_Card_Info> _Patient_Card_InfoRepository;
        private readonly IMapper _mapper;

        public PatientServices(IRepository<Patient> patientRepository, IRepository<Department> departmentRepository, IRepository<Doctor> doctorRepository, CSRedisClient cSRedisClient, IRepository<Patient_Card_Info> patient_Card_InfoRepository = null, IMapper mapper = null)
        {
            _patientRepository = patientRepository;
            _departmentRepository = departmentRepository;
            _doctorRepository = doctorRepository;
            _cSRedisClient = cSRedisClient;
            _Patient_Card_InfoRepository = patient_Card_InfoRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// 添加患者
        /// </summary>
        /// <param name="patient"> 患者信息 </param>
        /// <returns> APIResult </returns>
        [HttpPost("api/InsertPatient")]
        public async Task<APIResult<PatientInsertDto>> CreatePatient(PatientInsertDto patient)
        {
            Patient entity = ObjectMapper.Map<PatientInsertDto, Patient>(patient);



            //判断名称 是否重复
            var patientName = await _patientRepository.AllAsync(x => x.patient_name == patient.patient_name);
            if (patientName == true)
            {
                return new APIResult<PatientInsertDto>()
                {
                    Code = CodeEnum.error,
                    Message = "患者名称重复"
                };
            }
            else
            {
                await _patientRepository.InsertAsync(entity);
                return new APIResult<PatientInsertDto>()
                {
                    Code = 0,
                    Message = "添加患者成功",

                };
            }

        }

        /// <summary>
        /// 查询所有患者
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/his/patient/page")]
        public async Task<APIResult<List<PatientDto>>> GetPatients(string name, string phone)
        {
           
            
            // 生成 Redis 键
            string redisKey = $"patients:{name}:{phone}".ToLower();

            // 从 Redis 中获取缓存数据
            var cachedData = await _cSRedisClient.GetAsync(redisKey);

            APIResult<List<PatientDto>> result;  // 定义结果对象

            if (string.IsNullOrEmpty(cachedData))
            {
                // 如果缓存数据为空，继续从数据库查询
                var patientsList = await _patientRepository.GetListAsync();

                // 映射数据库结果到 DTO
                var patientDtos = _mapper.Map<List<Patient>, List<PatientDto>>(patientsList);

                // 根据过滤条件过滤患者列表
                if (!string.IsNullOrEmpty(name))
                {
                    patientDtos = patientDtos.Where(x => x.patient_name.Contains(name)).ToList();
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    patientDtos = patientDtos.Where(x => x.patient_contact == phone).ToList();
                }

                // 创建 API 结果对象
                result = new APIResult<List<PatientDto>>()
                {
                    Code = CodeEnum.success,
                    Message = "查询成功",
                    Data = patientDtos
                };

                // 将结果序列化并存储到 Redis
                var serializedData = JsonConvert.SerializeObject(result);
                await _cSRedisClient.SetAsync(redisKey, serializedData, 3600); // 存储到缓存，缓存有效期为 3600 秒（1小时）
            }
            else
            {
                // 如果缓存有数据，反序列化并返回
                result = JsonConvert.DeserializeObject<APIResult<List<PatientDto>>>(cachedData);
            }

            // 返回最终的结果
            return result;


            //var patientslst = await _patientRepository.GetListAsync();
            //var list = _mapper.Map<List<Patient>, List<PatientDto>>(patientslst);
            //var result = list.ToList();
            //if (!string.IsNullOrEmpty(name))
            //{
            //    result = result.Where(x => x.patient_name.Contains(name)).ToList();
            //}
            //if (!string.IsNullOrEmpty(phone))
            //{
            //    result = result.Where(x => x.patient_contact == phone).ToList();
            //}
            //return new APIResult<List<PatientDto>>()
            //{
            //    Code = CodeEnum.success,
            //    Message = "查询成功",
            //    Data = result
            //};
        }

        /// <summary>
        /// 一卡通 信息 新增
        /// </summary>
        /// <param name="patient_Card_Info"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/his/patient/insertPatientCardInfo")]
        public async Task<APIResult<Patient_Card_InfoDto>> CreatePatientCardInfo(Patient_Card_InfoDto patient_Card_Info)
        {
            Patient_Card_Info entity = ObjectMapper.Map<Patient_Card_InfoDto, Patient_Card_Info>(patient_Card_Info);
            await _Patient_Card_InfoRepository.InsertAsync(entity);
            return new APIResult<Patient_Card_InfoDto>()
            {
                Code = 0,
                Message = "添加患者一卡通信息成功",
            };
        }

        /// <summary>
        /// 查询所有病人名称和Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/his/patient/getPatientNameAndId")]
        public async Task<APIResult<List<PatientNameAndId>>> GetPatientNameAndId()
        {
            var patientslst = await _patientRepository.GetListAsync();
            var result = patientslst.Select(x => new PatientNameAndId { patient_name = x.patient_name, id = x.Id.ToString() }).ToList();
            return new APIResult<List<PatientNameAndId>>()
            {
                Code = CodeEnum.success,
                Message = "查询成功",
                Data = result
            };
        }
        /// <summary>
        /// 查询患者一卡通信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/his/patient/getPatientCardInfos")]
        public async Task<APIResult<List<PatientCardDto>>> GetPatientCardInfos()
        {
            var patientslst = await _patientRepository.GetListAsync();
            var patient_Card_Infolist = await _Patient_Card_InfoRepository.GetListAsync(a => a.Card_status == "启用");
            var list = from a in patientslst
                       join b in patient_Card_Infolist on a.Id.ToString() equals b.Patient_id.ToString()
                       select new PatientCardDto
                       {
                           patient_name = a.patient_name,
                           patient_contact = a.patient_contact,
                           emergency_contact = a.emergency_contact,
                           marital_status = a.marital_status,
                           CreationTime = a.CreationTime,
                           patient_age = a.patient_age,
                           patient_gender = a.patient_gender,
                           patient_address = a.patient_address,
                           patient_blood_type = a.patient_blood_type,
                           Card_status = b.Card_status,
                           Card_type = b.Card_type,
                       };
            var result = list.ToList();
            return new APIResult<List<PatientCardDto>>()
            {
                Code = CodeEnum.success,
                Message = "查询成功",
                Data = result
            };
        }

        /// <summary>
        /// 查询科室
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/his/patient/getDepartment")]
        public async Task<APIResult<List<DepartmentPatientDto>>> GetDepartment()
        {
            var departmentlst = await _departmentRepository.GetListAsync();
            var result = _mapper.Map<List<Department>, List<DepartmentPatientDto>>(departmentlst);
            return new APIResult<List<DepartmentPatientDto>>()
            {
                Code = CodeEnum.success,
                Message = "查询成功",
                Data = result
            };
        }

        /// <summary>
        /// 查询医生
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/his/patient/getDoctor")]
        public async Task<APIResult<List<Doctor>>> GetDoctor()
        {
            var doctorlst = await _doctorRepository.GetListAsync();
           
            return new APIResult<List<Doctor>>()
            {
                Code = CodeEnum.success,
                Message = "查询成功",
                Data = doctorlst
            };
        }

       

    }
}






