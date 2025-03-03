using DocumentFormat.OpenXml.EMMA;
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
            return new APIResult<List<SysMenuDto>>
            {
                Code = CodeEnum.success,
                Data = new List<SysMenuDto> {
                    new SysMenuDto
                    {
                        Component = "Layout",
                        Name = "/system",
                        Path = "/system",
                        Redirect = "/system/user",
                        Meta = new Meta
                        {
                            AlwaysShow = false,
                            Hidden = false,
                            Icon = "system",
                            Title = "系统管理"
                        },
                        Children = new List<SysMenuDto> {
                            new SysMenuDto
                            {
                                Component = "system/user/index",
                                Name = "User",
                                Path = "user",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "el-icon-User",
                                    Title = "用户管理"
                                }
                            },
                            new SysMenuDto
                            {
                                Component = "system/menu/index",
                                Name = "SysMenu",
                                Path = "menu",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "menu",
                                    Title = "菜单管理"
                                }
                            },
                            new SysMenuDto
                            {
                                Component = "system/dict/index",
                                Name = "Dict",
                                Path = "dict",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "dict",
                                    Title = "字典管理"
                                }
                            },
                            new SysMenuDto
                            {
                                Component = "system/dict/data",
                                Name = "DictData",
                                Path = "dict-data",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = true,
                                    KeepAlive = true,
                                    Icon = "dict",
                                    Title = "字典数据"
                                }
                            }
                        }

                    }
                    ,
                    new SysMenuDto
                    {
                        Component = "Layout",
                        Name = "/system/user",
                        Path = "/system/user",
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
                                Component = "system/user/settlementSystem",
                                Name = "Medicaredatamanagement",
                                Path = "Medicaredatamanagement",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "el-icon-User",
                                    Title = "医保数据管理"
                                },
                                Children = new List<SysMenuDto> {
                                    new SysMenuDto
                                    {
                                        Component = "system/user/settlementSystem",
                                        Name = "Fundsettlementlistuploaded",
                                        Path = "Fundsettlementlistuploaded",
                                        Meta = new Meta
                                        {
                                            AlwaysShow = false,
                                            Hidden = false,
                                            KeepAlive = true,

                                            Title = "基金结算清单上传"
                                        }
                                    },
                                    new SysMenuDto
                                    {
                                        Component = "system/user/settlementSystem",
                                        Name = "Fundsettlementlistquery",
                                        Path = "Fundsettlementlistquery",
                                        Meta = new Meta
                                        {
                                            AlwaysShow = false,
                                            Hidden = false,
                                            KeepAlive = true,

                                            Title = "医保进销存查询"
                                        }
                                    },
                                    new SysMenuDto
                                    {
                                        Component = "system/user/settlementSystem",
                                        Name = "",
                                        Path = "",
                                        Meta = new Meta
                                        {
                                            AlwaysShow = false,
                                            Hidden = false,
                                            KeepAlive = true,
                                            Title = "医保账户信息查询"
                                        }
                                    },
                                    new SysMenuDto
                                    {
                                        Component = "system/user/settlementSystem",
                                        Name = "Medicalinsurancedirectoryinquiry",
                                        Path = "Medicalinsurancedirectoryinquiry",
                                        Meta = new Meta
                                        {
                                            AlwaysShow = false,
                                            Hidden = false,
                                            KeepAlive = true,
                                            Title = "医保目录查询"
                                        }
                                    },
                                    new SysMenuDto
                                    {
                                        Component = "system/user/settlementSystem",
                                        Name = "Exceptionhandlingofmedicalinsurancetransactions",
                                        Path = "Exceptionhandlingofmedicalinsurancetransactions",
                                        Meta = new Meta
                                        {
                                            AlwaysShow = false,
                                            Hidden = false,
                                            KeepAlive = true,
                                            Title = "医保交易异常处理"
                                        }
                                    }
                                }
                            },
                            new SysMenuDto
                            {
                                Component = "system/user/settlementSystem",
                                Name = "MedicalPractitionerWorkstation",
                                Path = "MedicalPractitionerWorkstation",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "el-icon-User",
                                    Title = "医疗师工作站"
                                }
                            },
                            new SysMenuDto
                            {
                                Component = "system/user/settlementSystem",
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
                                        Component = "system/user/settlementSystem",
                                        Name = "PatientList",
                                        Path = "PatientList",
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
                                        Component = "system/user/settlementSystem",
                                        Name = "PatientDetail",
                                        Path = "PatientDetail",
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
                                Component = "system/user/settlementSystem",
                                Name = "Outpatientmanagement",
                                Path = "Outpatientmanagement",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "el-icon-User",
                                    Title = "门诊管理"
                                }
                            },
                            new SysMenuDto
                            {
                                Component = "system/user/settlementSystem",
                                Name = "Inpatientmanagement",
                                Path = "Inpatientmanagement",
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
                                Component = "system/user/settlementSystem",
                                Name = "Hospitalinformation",
                                Path = "Hospitalinformation",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "el-icon-User",
                                    Title = "号源管理"
                                }
                            },
                            new SysMenuDto
                            {
                                Component = "system/user/settlementSystem",
                                Name = "StatisticsReport",
                                Path = "StatisticsReport",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "el-icon-User",
                                    Title = "统计报表"
                                }
                            },
                            new SysMenuDto
                            {
                                Component = "system/user/settlementSystem",
                                Name = "HospitalManagement",
                                Path = "HospitalManagement",
                                Meta = new Meta
                                {
                                    AlwaysShow = false,
                                    Hidden = false,
                                    KeepAlive = true,
                                    Icon = "el-icon-User",
                                    Title = "院长查询"
                                }
                            }
                        }
                    }
                },
                Message = string.Empty
            };
        }
    }
}
