using AutoMapper;
using HIS.Fee_Categories;
using HIS.HIS.Chargemodules;
using HIS.HIS.Clinic_type_departments;
using HIS.HIS.Clinic_types;
using HIS.HIS.Departments;
using HIS.HIS.Doctors;
using HIS.HIS.FinancialInvoicesServices;
using HIS.HIS.InpatientRecords;
using HIS.HIS.NaturepatientServices;
using HIS.HIS.Patients;
using HIS.HIS.RegistrationServices;
using HIS.SettlementSystem;
using HIS.System_Administration;
using HIS.SystemDicServices;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;


namespace HIS;

public class HISApplicationAutoMapperProfile : Profile
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public HISApplicationAutoMapperProfile()
    {
        CreateMap<SysDict, SysDictDto>().ReverseMap();
        CreateMap<SysDictData, SysDictDataDto>().ReverseMap();
        CreateMap<SysDictListDto, SysDict>().ReverseMap();
        CreateMap<SysDictDataListDto, SysDictData>().ReverseMap();
        //患者
        CreateMap<PatientDto, Patient>().ReverseMap();

        //住院记录
        CreateMap<InpatientRecordDto, InpatientRecord>().ReverseMap();
        //医生
        CreateMap<DoctorDto, Doctor>().ReverseMap();
        //收费模块
        CreateMap<ChargemodulesDTO, Chargingmodule>().ReverseMap();
        CreateMap<GetChargemodulesByDepartmentDto, Chargingmodule>().ReverseMap();
        //挂号
        CreateMap<RegistrationDto, Registration>().ReverseMap();
        //门诊类型
        CreateMap<Clinic_typeDto, Clinic_type>().ReverseMap();
        //科室
        CreateMap<DepartmentDto, Department>().ReverseMap();
        //门诊类型科室
        CreateMap<Clinic_type_departmentDto, Clinic_type_department>().ReverseMap();
        //病人性质
        CreateMap<NaturepatientDTO, NatureofPatient>().ReverseMap();
        //科室
        CreateMap<DepartmentDto, Department>().ReverseMap();
        //费用类别
        CreateMap<Fee_CategoryDto, Fee_Category>().ReverseMap();
        //一卡通添加
        CreateMap<Patient_Card_InfoDto, Patient_Card_Info>().ReverseMap();
        CreateMap<PatientInsertDto, Patient>().ReverseMap();
        CreateMap<DepartmentPatientDto, Department>().ReverseMap();
        CreateMap<FinancialInvoicesDTO, FinancialInvoices>().ReverseMap();
       
    }
}
