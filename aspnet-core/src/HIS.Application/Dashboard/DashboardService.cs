using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.Dashboard
{
    
    [ApiExplorerSettings(GroupName = "v1")]
    public class DashboardService : ApplicationService
    {
        [HttpGet("/api/v1/logs/visit-trend")]
        public APIResult<dynamic> VisitTrend()
        {
            List<DateTime> trends = new List<DateTime>();

            int[] ipList = new int[7];

            int[] pvList = new int[7];

            Random rnd = new Random();

            for (int i = 0; i < 7; i++)
            {
                trends.Add(DateTime.Now.AddDays(-i));

                ipList[i] = rnd.Next(10, 500);
                pvList[i] = rnd.Next(300, 5000);
            }


            return new APIResult<dynamic>
            {
                Code = CodeEnum.success,
                Data = new
                {
                    dates = trends.Select(x => x.ToString("yyyy-MM-dd")),
                    ipList,
                    pvList,
                },
            };
        }

        [HttpGet("/api/v1/logs/visit-stats")]
        public APIResult<List<VisitStatoDto>> VisitStato()
        {
            return new APIResult<List<VisitStatoDto>>
            {
                Code = CodeEnum .success,
                Data = new List<VisitStatoDto>
                {
                    new VisitStatoDto
                    {
                        type = "pv",
                        title = "浏览量",
                        growthRate = 2.21F,
                        todayCount = 213,
                        totalCount = 475887,
                        granularityLabel = "日"
                    },
                    new VisitStatoDto
                    {
                        type = "uv",
                        title = "访问数",
                        growthRate = 0,
                        todayCount = 100,
                        totalCount = 2000,
                        granularityLabel = "日"
                    },
                    new VisitStatoDto
                    {
                        type = "ip",
                        title = "IP数",
                        growthRate = 0,
                        todayCount = 18,
                        totalCount = 29452,
                        granularityLabel = "日"
                    }
                }
            };
        }
    }





    public class VisitStatoDto
    {
        public string type { get; set; }
        public string title { get; set; }
        public int todayCount { get; set; }
        public int totalCount { get; set; }
        public float growthRate { get; set; }
        public string granularityLabel { get; set; }
    }
}
