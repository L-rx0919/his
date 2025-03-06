using HIS.SettlementSystem;
using HIS.System_Administration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.HIS.PatientCenters
{
    /// <summary>
    /// 患者中心
    /// </summary>
    [ApiExplorerSettings(GroupName = "v2")]
    public class PatientCenterService : ApplicationService, IPatientCenterService
    {
        private readonly IRepository<Doctor> doctorrepository;
        private readonly IRepository<Department> Departmentrepository;
        private readonly IRepository<Patient> patientrepository;
        private readonly IRepository<Patient_Card_Info> Patient_Card_Inforepository;
        private readonly IRepository<Chargingmodule> Chargingmodulerepository;

        public PatientCenterService(IRepository<Doctor> doctorrepository, IRepository<Department> departmentrepository, IRepository<Patient> patientrepository, IRepository<Patient_Card_Info> patient_Card_Inforepository, IRepository<Chargingmodule> chargingmodulerepository = null)
        {
            this.doctorrepository = doctorrepository;
            Departmentrepository = departmentrepository;
            this.patientrepository = patientrepository;
            Patient_Card_Inforepository = patient_Card_Inforepository;
            Chargingmodulerepository = chargingmodulerepository;
        }

        /// <summary>
        /// 联查
        /// </summary>
        /// <param name="patientName"></param>
        /// <returns></returns>
        [HttpGet("/api/v2/his/patientChenter/GetPatients")]
        public async Task<APIResult<List<PatientCenterDto>>> GetPatients(string patientName)
        {
            var patients = await patientrepository.GetListAsync(p => p.patient_name == patientName);
            var patient_Card_Infos = await Patient_Card_Inforepository.GetListAsync();
            var departments = await Departmentrepository.GetListAsync();
            var doctors = await doctorrepository.GetListAsync();
            var list = from a in patients
                       join b in patient_Card_Infos on a.Id equals b.Patient_id
                       join c in departments on b.Associated_dept equals c.Id.ToString()
                       join d in doctors on c.Id equals d.department_id
                       select new PatientCenterDto
                       {
                           patient_name = a.patient_name,
                           patient_gender = a.patient_gender,
                           patient_age = a.patient_age,
                           department_type = c.department_type,
                           key_department_name = d.name,
                           Balance = b.Balance,
                           name = d.name,
                           department_id=d.department_id
                       };
          var result = list.ToList();
            return new APIResult<List<PatientCenterDto>>()
            {
                Data = result,
                Message = "查询成功",
                Code = CodeEnum.success
            };
        }

        /// <summary>
        /// 费用账单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/v2/his/patientChenter/GetChargingModule")]
        public async Task<APIResult<List<ChargingModuleDto>>> GetChargingModule(string id)
        {
           var list =await Chargingmodulerepository.GetListAsync(p => p.DepartmentID.ToString() == id);
           var result = list.Select(p => new ChargingModuleDto
           {
             TemplateName = p.TemplateName,
           }).ToList();
            return new APIResult<List<ChargingModuleDto>>()
            {
                Data = result,
                Message = "查询成功",
                Code = CodeEnum.success
            };
        }

    }
}