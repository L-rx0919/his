using AutoMapper;
using HIS.Patients;
using HIS.RBAC;
using HIS.SettlementSystem;

namespace HIS;

public class HISApplicationAutoMapperProfile : Profile
{
    public HISApplicationAutoMapperProfile()
    {
        CreateMap<PatientDto, Patient>().ReverseMap();
        CreateMap<UserDTO, User>().ReverseMap();
    }
}
