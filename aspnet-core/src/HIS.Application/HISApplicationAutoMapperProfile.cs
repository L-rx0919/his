using AutoMapper;
using HIS.Patients;
using HIS.RBAC;
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
<<<<<<< HEAD
=======
        CreateMap<NaturePatientsDTO, NatureofPatient>().ReverseMap();
>>>>>>> a387a5aa91b40dba94b0b175c83c62cf5f17b954
    }
}
