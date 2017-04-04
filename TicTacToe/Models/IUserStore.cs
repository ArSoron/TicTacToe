using TicTacToe.Models;
namespace TicTacToe.Models
{
    public interface IUserStore
    {
        IUser Get(string ConnectionId);

        //IUser Update(string Login, string ConnectionId);

        IUser Create(string Login, string DisplayName, string ConnectionId);

    }
}