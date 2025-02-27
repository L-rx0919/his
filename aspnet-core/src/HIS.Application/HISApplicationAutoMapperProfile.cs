using AutoMapper;
using HIS.Chargingmodules;
using HIS.InpatientRecords;
using HIS.Patients;
using HIS.RBAC;
using HIS.RegistrationServices;
using HIS.SettlementSystem;

using HIS.System_Administration;
using HIS.SystemConfigurations;


namespace HIS;

public class HISApplicationAutoMapperProfile : Profile
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public HISApplicationAutoMapperProfile()
    {
        CreateMap<PatientDto, Patient>().ReverseMap();
        CreateMap<UserDTO, User>().ReverseMap();

        CreateMap<NaturePatientsDTO, NatureofPatient>().ReverseMap();
        CreateMap<InpatientRecordDto, InpatientRecord>().ReverseMap();

        CreateMap<NewchargingmoduleDTO, Chargingmodule>().ReverseMap();
    }
}
