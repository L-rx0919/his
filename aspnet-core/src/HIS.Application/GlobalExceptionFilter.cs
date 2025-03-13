using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 处理异常逻辑
            var exception = context.Exception;
            context.Result = new ContentResult
            {
                Content = $"An error occurred: {exception.Message}",
                ContentType = "text/plain",
                StatusCode = 500
            };
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // 处理结果执行逻辑
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            // 处理结果执行逻辑
        }   
    }
}
