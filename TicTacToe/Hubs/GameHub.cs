using Microsoft.AspNet.SignalR;
using TicTacToe.Models;

namespace TicTacToe.Hubs
{
    public class GameHub : Hub
    {
        private readonly IUserStore userStore = UserStore.Instance;
        private readonly IGameStore gameStore = GameStore.Instance;
        public void Start()
        {
            gameStore.Join(userStore.Get(Context.ConnectionId));
        }
    }
}