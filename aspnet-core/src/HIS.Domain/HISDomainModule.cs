using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace HIS;

[DependsOn(
    typeof(HISDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpBackgroundJobsDomainModule)
)]
public class HISDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        //Configure<AbpMultiTenancyOptions>(options =>
        //{
        //    options.IsEnabled = MultiTenancyConsts.IsEnabled;
        //});
#if DEBUG
        //context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}
