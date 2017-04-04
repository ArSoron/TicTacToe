namespace TicTacToe.Models
{
    public interface IGameStore
    {
        IGame Get(string id);

        IGame Join(IUser user);

    }
}