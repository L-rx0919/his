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
        Task<APIResult<UserDTO>> AddUser(UserDTO user);

        /// <summary>
        /// 异步用户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        Task<APIResult<UserDTO>> Login(string UserName, string UserPwd);

        APIResult<CaptchaDto> Captcha(string id);
    }
}
