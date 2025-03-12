using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;
using Volo.Abp.Application.Services;

namespace HIS
{
    public class ChatHub : Hub
    {
        private Dictionary<string, string> userList;

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public ChatHub(Dictionary<string, string> userList)
        {
            this.userList = userList;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="to"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Send(string user, string to, string message)
        {
            if (string.IsNullOrEmpty(to))
            {
                await Clients.All.SendAsync("Receive", user, message, DateTime.Now);
            }
            else
            {
                await Clients.Client(userList.Single(m => m.Value == to).Key).SendAsync("Receive", user, message, DateTime.Now);
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddUsers(string user)
        {
            userList.Add(Context.ConnectionId, user);
            //刷新用户列表
            await Clients.All.SendAsync("RefreshUser", userList);
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //移动当前断开连接的用户
            userList.Remove(Context.ConnectionId);
            //再次刷新用户列表
            await Clients.All.SendAsync("RefreshUser", userList);
        }
    }
}
