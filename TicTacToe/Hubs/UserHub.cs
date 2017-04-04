using Microsoft.AspNet.SignalR;
using TicTacToe.Models;

namespace TicTacToe.Hubs
{
    public class UserHub : Hub
    {
        private readonly IUserStore userStore = UserStore.Instance;
        public void Login(string login)
        {   IUser user = userStore.Create(login, login, Context.ConnectionId);
            Clients.Caller.setUser(user);
        }
    }
}