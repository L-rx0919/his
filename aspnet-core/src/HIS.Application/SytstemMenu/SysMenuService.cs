using DocumentFormat.OpenXml.EMMA;
using HIS.System_Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.SytstemMenu
{

    [ApiExplorerSettings(GroupName = "v1")]
    public class SysMenuService : ApplicationService
    {
        private readonly IRepository<SysMenu> repository;

        public SysMenuService(IRepository<SysMenu> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 获取路由
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/menus/routes")]
        public async Task<APIResult<List<SysMenuDto>>> Routes()
        {
            await Task.CompletedTask; // TODO: 实现获取路由逻辑
            return new APIResult<List<SysMenuDto>>
            {
                Code = CodeEnum.success,
                Data = new List<SysMenuDto> {

                    new SysMenuDto
                    {
                   Component = "Layout",
    Name = "/system/user",
    Path = "/his",
    Redirect = "/system/user/settlementSystem",
    Meta = new Meta
    {
        AlwaysShow = false,
        Hidden = false,
        Icon = "el-icon-User",
        Title = "结算信息系统"
    },
    Children = new List<SysMenuDto> {

        new SysMenuDto
        {
            Component = "his/PatientInformation",
            Name = "PatientInformation",
            Path = "PatientInformation",
            Meta = new Meta
            {
                AlwaysShow = false,
                Hidden = false,
                KeepAlive = true,
                Icon = "el-icon-User",
                Title = "病人信息"
            },
             Children = new List<SysMenuDto> {
                new SysMenuDto
                {
                    Component = "his/PatientInformation/patient/index",
                    Name = "patient",
                    Path = "patient",
                    Meta = new Meta
                    {
                        AlwaysShow = false,
                        Hidden = false,
                        KeepAlive = true,
                        Title = "病人列表"
                    }
                },
                new SysMenuDto
                {
                    Component = "his/PatientInformation/patientCenter/index",
                    Name = "patientCenter",
                              Path = "patientCenter",
                    Meta = new Meta
                    {
                        AlwaysShow = false,
                        Hidden = false,
                        KeepAlive = true,
                        Title = "住院患者中心"
                    }
                }
                      }
                    },
                          new SysMenuDto
                            {
                                Component = "his/inpatientRecord/index",
                                Name = "Inpatientmanagement",
                                Path = "inpatientmanagement",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "el-icon-User",
                                    Title = "住院管理"
                                }
                            },
                             new SysMenuDto
                            {
                               Component = "his/systemconfig/index",
                                Name = "systemconfig",
                                Path = "systemconfig",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "el-icon-User",
                                    Title = "系统配置"
                                },
                                Children = new List<SysMenuDto> {
                                    new SysMenuDto
                                    {
                                        Component = "his/systemconfig/patientCategory/index",
                                        Name = "PatientCategory",
                                        Path = "PatientCategory",
                                        Meta = new Meta
                                        {
                                            AlwaysShow = false,
                                            Hidden = false,
                                            KeepAlive = true,
                                            Title = "病人性质"
                                        }
                                    },
                                    new SysMenuDto
                                    {
                                        Component = "his/systemconfig/chargingmodule/index",
                                        Name = "Chargingmodule",
                                        Path = "Chargingmodule",
                                        Meta = new Meta
                                        {
                                            AlwaysShow = false,
                                            Hidden = false,
                                            KeepAlive = true,
                                            Title = "收费模板维护"
                                        }
                                    },
                                     new SysMenuDto
                                    {
                                        Component = "his/systemconfig/index",
                                        Name = "Chargingprojects",
                                        Path = "Chargingprojects",
                                        Meta = new Meta
                                        {
                                            AlwaysShow = false,
                                            Hidden = false,
                                            KeepAlive = true,
                                            Title = "财务收据配置"
                                        }
                                    },
                                    new SysMenuDto
                                    {
                                      Component = "his/systemconfig/index",
                                      Name = "SystemDynamics",
                                      Path = "SystemDynamics",
                                      Meta = new Meta
                                      {
                                         AlwaysShow = false,
                                         Hidden = false,
                                         KeepAlive = true,
                                         Title = "系统动态参数配置"
                                      }
                                   },
                                     new SysMenuDto
                                    {
                                       Component = "his/systemconfig/index",
                                       Name = "PatientDetail",
                                       Path = "PatientDetail",
                                       Meta = new Meta
                                       {
                                         AlwaysShow = false,
                                         Hidden = false,
                                         KeepAlive = true,
                                         Title = "收费项目组合配置"
                                       }
                                     },
                                     new SysMenuDto
                                     {
                                       Component = "his/systemconfig/index",
                                       Name = "PatientDetail",
                                       Path = "PatientDetail",
                                       Meta = new Meta
                                       {
                                        AlwaysShow = false,
                                       Hidden = false,
                                       KeepAlive = true,
                                       Title = "系统用户"
                                       }
                                     },
                                        new SysMenuDto
                                        {
                                          Component = "his/systemconfig/index",
                                          Name = "InvoiceConfiguration",
                                          Path = "InvoiceConfiguration",
                                          Meta = new Meta
                                          {
                                                     AlwaysShow = false,
                                             Hidden = false,
                                             KeepAlive = true,
                                             Title = "财务发票配置"
                                          }
                                        },
                                      new SysMenuDto
                                      {
                                          Component = "his/systemconfig/index",
                                          Name = "Rolemanagements",
                                          Path = "Rolemanagements",
                                          Meta = new Meta
                                          {
                                           AlwaysShow = false,
                                           Hidden = false,
                                           KeepAlive = true,
                                           Title = "角色管理"
                                          }
                                      },

                                       new SysMenuDto
                                      {
                                          Component = "his/systemconfig/index",
                                          Name = "SystemMenu",
                                          Path = "SystemMenu",
                                          Meta = new Meta
                                          {
                                           AlwaysShow = false,
                                           Hidden = false,
                                           KeepAlive = true,
                                           Title = "系统菜单"
                                          }
                                      },
                                       new SysMenuDto
                                     {
                                         Component = "his/systemconfig/index",
                                         Name = "DepartmentDocto",
                                         Path = "DepartmentDocto",
                                         Meta = new Meta
                                         {
                                          AlwaysShow = false,
                                          Hidden = false,
                                          KeepAlive = true,
                                          Title = "科室医生信息绑定"
                                         }
                                     },
                                }
                            },
                            new SysMenuDto
                            {
                                Component = "his/sms/index",
                                Name = "sms",
                                Path = "sms",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "el-icon-User",
                                    Title = "短信"
                                }
                            },
                        }
                    }
                },
                Message = string.Empty
            };
        }
    }
}
