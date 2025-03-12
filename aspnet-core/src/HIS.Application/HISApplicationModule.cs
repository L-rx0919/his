using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.ExceptionHandling;
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
        //注入redis
        ConfigureRedis(context, context.Services.GetConfiguration());
        //注入全局异常处理
        GlobalException(context, context.Services.GetConfiguration());

    }

    private void ConfigureRedis(ServiceConfigurationContext context, IConfiguration configuration)
    {
        CSRedis.CSRedisClient cSRedis = new CSRedis.CSRedisClient(configuration["Redis:Configuration"]);
        //注入redis
        context.Services.AddSingleton(cSRedis);
    }

    private void GlobalException(ServiceConfigurationContext context, IConfiguration configuration)
    {
        //全局异常处理
        context.Services.Configure<AbpExceptionHandlingOptions>(options =>
        {
            options.SendExceptionsDetailsToClients = true;
            options.SendStackTraceToClients = true;
            options.SendExceptionDataToClientTypes.Add(typeof(GlobalExceptionFilter));
        });
    }
}
