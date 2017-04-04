using System;

namespace TicTacToe.Models
{
    public class User : IUser
    {
        public string Login { get; set; }

        public string DisplayName { get; set; }

        public string ConnectionId { get; set; }
    }
}
