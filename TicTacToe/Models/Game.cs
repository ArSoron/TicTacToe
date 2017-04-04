using System;

namespace TicTacToe.Models
{
    public class Game : IGame
    {
        public Game() {
            Id = Guid.NewGuid().ToString();
            Status = GameStatus.NotStarted;
        }
        public string Id { get; }

        public GameStatus Status { get; set; }
        public IUser Player1 { get; set; }
        public IUser Player2 { get; set; }

        public IPosition Position { get; }

        public IPosition MakeMove(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
