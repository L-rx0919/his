using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HIS.RBAC
{
    /// <summary>
    /// RBAC接口
    /// </summary>
    public interface IServicesUsers:IApplicationService
    {
        /// <summary>
        /// 异步添加新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<APIResult1<UserDTO>> AddUser(UserDTO user);

        /// <summary>
        /// 异步用户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        APIResult<LoginResult> LoginAsync(LoginDto loginDto);
        /// <summary>
        /// 异步获取验证码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        APIResult<CaptchaDto> Captcha(string id);
        /// <summary>
        /// 异步获取用户信息
        /// </summary>
        /// <returns></returns>

        Task<APIResult<List<LoginDataDto>>> GetUserAsync();
    }
}
