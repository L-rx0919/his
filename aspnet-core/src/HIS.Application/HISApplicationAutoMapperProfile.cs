using AutoMapper;
using HIS.SystemDicServices;


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
    }
}
