using AutoMapper;
using HIS.Clinic_types;
using HIS.Patients;
using HIS.RBAC;
using HIS.RegistrationServices;
using HIS.SettlementSystem;
using HIS.System_Administration;
using HIS.SystemConfigurations;

namespace HIS;

public class HISApplicationAutoMapperProfile : Profile
{
    public HISApplicationAutoMapperProfile()
    {
        CreateMap<PatientDto, Patient>().ReverseMap();
        CreateMap<UserDTO, User>().ReverseMap();
        CreateMap<NaturePatientsDTO, NatureofPatient>().ReverseMap();
        CreateMap<NaturePatientsDTO, NatureofPatient>().ReverseMap();
        CreateMap<RegistrationDto,Registration>().ReverseMap();
        CreateMap<Clinic_typeDto,Clinic_type>().ReverseMap();
    }
}
