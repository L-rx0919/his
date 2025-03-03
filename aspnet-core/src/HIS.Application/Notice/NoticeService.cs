using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HIS.Notice
{
   
    [ApiExplorerSettings(GroupName = "v1")]
    public class NoticeService : ApplicationService
    {
        private readonly IRepository<SysNotice> repositorySysNotice;
        private readonly IRepository<SystemUser> repositoryUser;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IRepository<SysUserNotice> repositorySysUserNotice;

        public NoticeService(IRepository<SysNotice> repositorySysNotice, IRepository<SystemUser> repositoryUser, IHttpContextAccessor httpContextAccessor, IRepository<SysUserNotice> repositorySysUserNotice)
        {
            this.repositorySysNotice = repositorySysNotice;
            this.repositoryUser = repositoryUser;
            this.httpContextAccessor = httpContextAccessor;
            this.repositorySysUserNotice = repositorySysUserNotice;
        }

       /// <summary>
       /// 获取通知列表
       /// </summary>
       /// <param name="pageParamsDto"></param>
       /// <param name="IsRead"></param>
       /// <returns></returns>
        [HttpGet("/api/v1/notices/my-page")]
        public async Task<APIResult<NoticeData>> QueryNoticeAsync([FromQuery]PageParamsDto pageParamsDto, int? IsRead)
        {
            var userId = httpContextAccessor.HttpContext.User.Claims.First(m => m.Type == ClaimTypes.NameIdentifier).Value;

            var userList = await repositoryUser.GetListAsync();

            var list = (from a in await repositorySysNotice.GetQueryableAsync()
                        join b in await repositorySysUserNotice.GetQueryableAsync()
                        on a.Id equals b.NoticeId
                        select new NoticeDto
                        {
                            Id = a.Id,
                            IsRead = b.IsRead,
                            Level = "M",
                            PublishTime = a.CreationTime,
                            Title = a.Title,
                            Type = a.NoticeType,
                            CreatorId = a.CreatorId,
                            UserId = b.UserId
                        }).Where(m=>m.UserId == Guid.Parse(userId));

            if (IsRead != null) 
            {
                list = list.Where(m=>m.IsRead == Convert.ToBoolean(IsRead));
            }

            var data = list.OrderByDescending(m => m.PublishTime).Take(10).ToList();

            data.ForEach(x => { 
                x.PublishName = userList.FirstOrDefault(m => m.Id == x.UserId).Username;
            });

            return new APIResult<NoticeData> 
            {
                Code = CodeEnum.success,
                Data = new NoticeData { 
                    List = list.OrderByDescending(m => m.PublishTime).Take(10).ToList()
                },
            };
        }


        /// <summary>
        /// 初始化通知数据
        /// </summary>
        /// <returns></returns>
        public async Task<APIResult<bool>> InitData()
        {
            try
            {
                await repositorySysNotice.InsertManyAsync(new List<SysNotice>()
                {
                    new SysNotice
                    {
                        Title = "物联网学院2202B班项目进入开发阶段",
                        NoticeType = NoticeType.News,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = true,
                    },
                    new SysNotice
                    {
                        Title = "v2.16.1 版本修复了 WebSocket 重复连接导致的后台线程阻塞问题",
                        NoticeType = NoticeType.Upgrade,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = true,
                    },
                    new SysNotice
                    {
                        Title = "公司将在 10 月 15 日举办新产品发布会，敬请期待。",
                        NoticeType = NoticeType.News,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = true,
                    },
                    new SysNotice
                    {
                        Title = "国庆假期从 10 月 1 日至 10 月 7 日放假，共 7 天。",
                        NoticeType = NoticeType.Notice,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = true,
                    },
                    new SysNotice
                    {
                        Title = "最近发现一些钓鱼邮件，请大家提高警惕，不要点击陌生链接。",
                        NoticeType = NoticeType.Warning,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = false,
                    },
                    new SysNotice
                    {
                        Title = "系统将于本周六凌晨 2 点进行维护，预计维护时间为 2 小时。",
                        NoticeType = NoticeType.Maintain,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = false,
                    },
                    new SysNotice
                    {
                        Title = "v2.16.0 通知公告、字典翻译组件。",
                        NoticeType = NoticeType.Upgrade,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = false,
                    },
                    new SysNotice
                    {
                        Title = "v2.15.0 登录页面改造。",
                        NoticeType = NoticeType.Upgrade,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = false,
                    },
                    new SysNotice
                    {
                        Title = "v2.14.0 新增个人中心。",
                        NoticeType = NoticeType.Upgrade,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = false,
                    },
                    new SysNotice
                    {
                        Title = "v2.13.0 新增菜单搜索。",
                        NoticeType = NoticeType.Upgrade,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = false,
                    },
                    new SysNotice
                    {
                        Title = "v2.12.0 新增系统日志，访问趋势统计功能。",
                        NoticeType = NoticeType.Upgrade,
                        TargetType = TargetType.All,
                        Content = "这是内容",
                        IsDeleted = false,
                    }
                }, true);

                foreach (var item in await repositorySysNotice.GetListAsync())
                {
                    await repositorySysUserNotice.InsertAsync(new SysUserNotice
                    {
                        NoticeId = item.Id,
                        UserId = Guid.Parse("BD9AC84B-A7CD-DA3E-3E29-3A15C06D5161")
                    }, true);
                }

                return new APIResult<bool>
                {
                    Code = CodeEnum.success,
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new APIResult<bool>
                {
                    Code = CodeEnum.success,
                    Data = false,
                    Message = e.Message
                };
            }
        }
    }
}
