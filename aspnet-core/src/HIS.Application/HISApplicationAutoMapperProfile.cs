using AutoMapper;
using HIS.InpatientRecords;
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
        CreateMap<NaturePatientsDTO, NatureofPatient>().ReverseMap();
        CreateMap<InpatientRecordDto, InpatientRecord>().ReverseMap();
    }
}
