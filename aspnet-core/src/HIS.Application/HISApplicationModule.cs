using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace HIS;

[DependsOn(
    typeof(HISDomainModule),
    typeof(HISApplicationContractsModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class HISApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<HISApplicationModule>();
        });
    }
}
