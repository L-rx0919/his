using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAParser;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace HIS.AuditLogs
{
    [ApiExplorerSettings(GroupName = "v1")]
  
    public class AuditLogService : ApplicationService
    {
        private readonly IAuditLogRepository auditLogRepository;

        public AuditLogService(IAuditLogRepository auditLogRepository)
        {
            this.auditLogRepository = auditLogRepository;
        }

        /// <summary>
        /// 日志管理
        /// </summary>
        /// <param name="pageAndQueryAndTimeRange"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/logs/page")]
        public async Task<APIResult<PageResultDto<AuditLog>>> AuditLogPageAsync([FromQuery] PageAndQueryAndTimeRange pageAndQueryAndTimeRange)
        {
            #region UA解析，不太准确
            var parser = Parser.GetDefault();
            var info = parser.Parse("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36 Edg/118.0.2088.76");
            #endregion

            #region 获取详细日志的三种方式
            /*var list1 = await auditLogRepository.GetListAsync();

            var list = (await auditLogRepository.WithDetailsAsync()).ToList();

            var list2 = await auditLogRepository.GetPagedListAsync(skipCount: (PageIndex - 1) * PageSize,
                maxResultCount: PageSize, sorting: "", includeDetails: true);
            */
            #endregion

            var list = await auditLogRepository.WithDetailsAsync();
            list = list.WhereIf(!string.IsNullOrEmpty(pageAndQueryAndTimeRange.Keywords), m => m.Url.Contains(pageAndQueryAndTimeRange.Keywords));
            list = list.WhereIf(pageAndQueryAndTimeRange.StartTime != null, m => m.ExecutionTime >= pageAndQueryAndTimeRange.StartTime);
            list = list.WhereIf(pageAndQueryAndTimeRange.EndTime != null, m => m.ExecutionTime <= pageAndQueryAndTimeRange.EndTime);

            return new APIResult<PageResultDto<AuditLog>>
            {
                Code = CodeEnum.success,
                Data = new PageResultDto<AuditLog>
                {
                    List = list
                    .OrderByDescending(m => m.ExecutionTime)
                    .Skip((pageAndQueryAndTimeRange.PageNum - 1) * pageAndQueryAndTimeRange.PageSize)
                    .Take(pageAndQueryAndTimeRange.PageSize)
                    .ToList(),
                    Total = list.Count()
                }
            };
        }
    }
}
