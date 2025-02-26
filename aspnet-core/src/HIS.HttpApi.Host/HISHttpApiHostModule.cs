using HIS.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace HIS;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HISApplicationModule),
    typeof(HISEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
)]
public class HISHttpApiHostModule : AbpModule
{

    /// <summary>
    ///  配置服务
    /// </summary>
    /// <param name="context"></param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAntiForgeryOptions>(a =>
        {
            a.TokenCookie.Expiration = TimeSpan.FromDays(1);
            a.AutoValidate = false;
        });

        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        ConfigureAuthentication(context);
        ConfigureBundles();
        ConfigureUrls(configuration);
        ConfigureConventionalControllers();
        ConfigureVirtualFileSystem(context);
        ConfigureCors(context, configuration);
        ConfigureSwaggerServices(context, configuration);
        ConfigureLocalization();
    }
    private void ConfigureAuthentication(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        //Jwt
        context.Services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(
                        option =>
                        {
                            option.TokenValidationParameters = new TokenValidationParameters
                            {
                                //是否验证发行人
                                ValidateIssuer = true,
                                ValidIssuer = configuration["JwtConfig:Bearer:Issuer"],//发行人

                                //是否验证受众人
                                ValidateAudience = true,
                                ValidAudience = configuration["JwtConfig:Bearer:Audience"],//受众人

                                //是否验证密钥
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Bearer:SecurityKey"]!)),

                                ValidateLifetime = true, //验证生命周期

                                RequireExpirationTime = true, //过期时间

                                ClockSkew = TimeSpan.FromSeconds(30)   //平滑过期偏移时间
                            };
                        }
                    );
    }
    /// <summary>
    /// 不修改
    /// </summary>
    private void ConfigureBundles()
    {
        Configure<AbpBundlingOptions>(options =>
        {
            options.StyleBundles.Configure(
                LeptonXLiteThemeBundles.Styles.Global,
                bundle =>
                {
                    bundle.AddFiles("/global-styles.css");
                }
            );
        });
    }
    /// <summary>
    /// 配置Url
    /// </summary>
    /// <param name="configuration"></param>
    private void ConfigureUrls(IConfiguration configuration)
    {
        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            options.RedirectAllowedUrls.AddRange(configuration["App:RedirectAllowedUrls"]?.Split(',') ?? Array.Empty<string>());
        });
    }
    /// <summary>
    /// 不修改
    /// </summary>
    /// <param name="context"></param>
    private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<HISDomainSharedModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}HIS.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<HISDomainModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}HIS.Domain"));
                options.FileSets.ReplaceEmbeddedByPhysical<HISApplicationContractsModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}HIS.Application.Contracts"));
                options.FileSets.ReplaceEmbeddedByPhysical<HISApplicationModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}HIS.Application"));
            });
        }
    }
    /// <summary>
    /// 不修改
    /// </summary>
    private void ConfigureConventionalControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(HISApplicationModule).Assembly);
        });
    }
    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddSwaggerGen(
     options =>
     {
         options.SwaggerDoc("v2", new OpenApiInfo { Title = "业务接口", Version = "v2" });
         options.SwaggerDoc("v1", new OpenApiInfo { Title = "基础接口", Version = "v1" });

         options.DocInclusionPredicate((doc, desc) =>
         {
             return desc.GroupName == doc;
         });

         //开启权限小锁
         options.OperationFilter<AddResponseHeadersFilter>();
         options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
         options.OperationFilter<SecurityRequirementsOperationFilter>();
         options.CustomSchemaIds(type => type.FullName);

         //给参数设置默认值
         //options.SchemaFilter<SchemaFilter>();

         //在header中添加token，传递到后台
         options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
         {
             Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
             Name = "Authorization",//jwt默认的参数名称
             In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
             Type = SecuritySchemeType.ApiKey
         });

         //就是这里！！！！！！！！！
         var basePath = AppDomain.CurrentDomain.BaseDirectory;
         var xmlPath = Path.Combine(basePath, "HIS.HttpApi.Host.xml");//这个就是刚刚配置的xml文件名
         options.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
     }
 );

    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            //options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
            //options.Languages.Add(new LanguageInfo("is", "is", "Icelandic", "is"));
            //options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            //options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
            //options.Languages.Add(new LanguageInfo("es", "es", "Español", "es"));
            options.Languages.Add(new LanguageInfo("el", "el", "Ελληνικά"));
        });
    }
    /// <summary>
    /// 配置Cors
    /// </summary>
    /// <param name="context"></param>
    /// <param name="configuration"></param>
    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(configuration["App:CorsOrigins"]?
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(o => o.RemovePostFix("/"))
                        .ToArray() ?? Array.Empty<string>())
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }
    /// <summary>
    /// 配置应用
    /// </summary>
    /// <param name="context"></param>
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseCorrelationId();
        app.MapAbpStaticAssets();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();



        app.UseUnitOfWork();
        app.UseDynamicClaims();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "基础接口");

            c.SwaggerEndpoint("/swagger/v2/swagger.json", "业务接口");

            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            c.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            c.OAuthScopes("HIS");
        });

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
