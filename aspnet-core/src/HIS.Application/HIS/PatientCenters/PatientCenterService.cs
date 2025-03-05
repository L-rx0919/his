using HIS.SettlementSystem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
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

        public PatientCenterService(IRepository<Doctor> doctorrepository, IRepository<Department> departmentrepository, IRepository<Patient> patientrepository, IRepository<Patient_Card_Info> patient_Card_Inforepository)
        {
            this.doctorrepository = doctorrepository;
            Departmentrepository = departmentrepository;
            this.patientrepository = patientrepository;
            Patient_Card_Inforepository = patient_Card_Inforepository;
        }

        /// <summary>
        /// 联查
        /// </summary>
        /// <param name="patientName"></param>
        /// <returns></returns>
        [HttpGet("/api/PatientCenter/GetPatients")]
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
                       };
          var result = list.ToList();
            return new APIResult<List<PatientCenterDto>>()
            {
                Data = result,
                Message = "查询成功",
                Code = CodeEnum.success
            };
        }

    }
}