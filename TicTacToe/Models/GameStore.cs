using Microsoft.AspNet.SignalR;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using TicTacToe.Hubs;

namespace TicTacToe.Models {
    public class GameStore : IGameStore
    {
        private static volatile GameStore instance;
        private static object syncRoot = new Object();

        private readonly Hashtable gameStorage = new Hashtable();
        private IGame availableGame;

        private GameStore() { }

        public static GameStore Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GameStore();
                    }
                }

                return instance;
            }
        }

        public IGame Get(string id)
        {
            return gameStorage[id] as IGame;
        }

        public IGame Join(IUser user)
        {
            lock (syncRoot)
            {
                if (availableGame != null)
                {
                    availableGame.Player2 = user;
                    availableGame.Status = GameStatus.Ongoing;
                    gameStorage[availableGame.Id] = availableGame;
                    var context = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
                    context.Clients.Client(availableGame.Player1.ConnectionId).gameStarted(availableGame);
                    context.Clients.Client(availableGame.Player2.ConnectionId).gameStarted(availableGame);
                    availableGame = null;
                }
                else
                {
                    availableGame = new Game() { Player1 = user };
                }
                return availableGame;
            }
        }
    }
}