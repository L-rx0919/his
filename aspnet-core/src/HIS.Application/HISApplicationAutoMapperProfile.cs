using AutoMapper;
using HIS.Chargingmodules;
using HIS.Patients;
using HIS.RBAC;
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

       CreateMap<NaturePatientsDTO,NatureofPatient>().ReverseMap();

        CreateMap<ChargemodulesDTO, Chargingmodule>().ReverseMap();
        CreateMap<InsertRoleDto, Role>().ReverseMap();
        CreateMap<InsertPermissionDto, Permissions>().ReverseMap();
        CreateMap<RolePermissionDTO,RolePermissions>().ReverseMap();
        CreateMap<UserRoleDto,UserRole>().ReverseMap();


        CreateMap<NewchargingmoduleDTO, Chargingmodule>().ReverseMap();
    }
}
