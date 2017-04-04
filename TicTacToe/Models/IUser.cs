namespace TicTacToe.Models
{
    public interface IUser
    {
        string Login { get; }

        string DisplayName { get; }

        string ConnectionId { get; set; }
    }
}
