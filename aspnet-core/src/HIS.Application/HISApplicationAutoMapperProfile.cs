using AutoMapper;
using HIS.Patients;
using HIS.SettlementSystem;

namespace HIS;

public class HISApplicationAutoMapperProfile : Profile
{
    public HISApplicationAutoMapperProfile()
    {
        CreateMap<PatientDto, Patient>().ReverseMap();
    }
}
