using Microsoft.AspNet.SignalR;
using TicTacToe.Models;

public class ChatHub : Hub
{
    private readonly IUserStore userStore = UserStore.Instance;
    public void Send(string message)
    {
        // Call the addNewMessageToPage method to update clients.
        Clients.All.addNewMessageToPage(userStore.Get(Context.ConnectionId).DisplayName, message);
    }
}