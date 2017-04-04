using System;
using System.Collections;

namespace TicTacToe.Models
{
    public interface IGame
    {
        string Id { get; }
        GameStatus Status { get; set; }
        IUser Player1 { get; set; }
        IUser Player2 { get; set; }
        IPosition Position { get; }
        IPosition MakeMove(int x, int y);
    }
    public enum GameStatus
    {
        NotStarted = 0,
        Ongoing,
        Finished
    }
}

