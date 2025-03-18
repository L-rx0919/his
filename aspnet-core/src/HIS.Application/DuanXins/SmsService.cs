using AlibabaCloud.TeaUtil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks; // Required for asynchronous tasks
using Tea;
using Volo.Abp.Application.Services;

namespace HIS.DuanXins
{
    [ApiExplorerSettings(GroupName = "v2")]
    public class SmsService : ApplicationService
    {
        /// <summary>
        ///     阿里云短信服务的配置对象
        /// </summary>
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("/api/v2/his/sms/sendSmsAsync")]
        public async Task<APIResult<bool>> SendSmsAsync(string phoneNumber)
        {
            var accessKeyId = _configuration["AliyunSms:AccessKeyId"];
            var accessKeySecret = _configuration["AliyunSms:AccessKeySecret"];
            var regionId = _configuration["AliyunSms:RegionId"];
            // Check if the configuration values are valid
            if (string.IsNullOrEmpty(accessKeyId) || string.IsNullOrEmpty(accessKeySecret) || string.IsNullOrEmpty(regionId))
            {
                throw new InvalidOperationException("Aliyun configuration is not properly set.");
            }

            // Initialize the configuration
            var config = new AlibabaCloud.OpenApiClient.Models.Config
            {
                AccessKeyId = accessKeyId,
                AccessKeySecret = accessKeySecret,
                RegionId = regionId
            };

            // Initialize the client
            var client = new AlibabaCloud.SDK.Dysmsapi20170525.Client(config);

            //随机一个验证码
            Random random = new Random();
            int code = random.Next(100000, 999999);

            var sendSmsRequest = new AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsRequest
            {
                PhoneNumbers = phoneNumber,  // Replace with the recipient's phone number
                SignName = "阿里云短信测试",   // Replace with your Sign Name
                TemplateCode = "SMS_154950909", // Replace with your SMS template code
                TemplateParam = "{\"code\":" + code + "}"
            };

            var runtimeOptions = new RuntimeOptions();

            try
            {
                // Send the SMS request asynchronously
                var response = await client.SendSmsWithOptionsAsync(sendSmsRequest, runtimeOptions);

                // Log and process the response if necessary
                if (response.Body.Code == "OK")
                {
                    // SMS sent successfully
                    return  new APIResult<bool>()
                    {
                        Code = CodeEnum.success,
                        Message = "短信发送成功",
                        Data = true
                    };
                }
                else
                {
                    // Handle failure (e.g., logging)
                    Console.WriteLine($"Error: {response.Body.Message}");
                    return new APIResult<bool>()
                    {
                        Code = CodeEnum.success,
                        Message = "短信发送失败",
                        Data = false

                    };
                }
            }
            catch (TeaException e)
            {
                // Handle exception and log error message
                Console.WriteLine($"Exception occurred: {e.Message}");
               return new APIResult<bool>()
                {
                    Code = CodeEnum.error,
                    Message = "短信发送失败",
                    Data = false
                }; 
            }
        }
    }
}
