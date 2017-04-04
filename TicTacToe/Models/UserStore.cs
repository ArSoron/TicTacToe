using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Models {
    public class UserStore : IUserStore
    {
        private static volatile UserStore instance;
        private static object syncRoot = new Object();

        private readonly Hashtable userStorage = new Hashtable();

        private UserStore() { }

        public static UserStore Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UserStore();
                    }
                }

                return instance;
            }
        }

        public IUser Create(string Login, string DisplayName, string ConnectionId)
        {
            if (userStorage[ConnectionId] != null) throw new ValidationException("Already in use");
            IUser user = new User() { Login = Login, DisplayName = DisplayName, ConnectionId = ConnectionId };
            userStorage.Add(ConnectionId, user);
            return user;
        }

        //public IUser Update(string Login, string ConnectionId)
        //{
        //    IUser user = userStorage[ConnectionId] as IUser;
        //    if (user == null) return null;
        //    user.Login = Login;
        //    user.ConnectionId = ConnectionId;
        //    userStorage[ConnectionId] = user;
        //    return user;
        //}

        public IUser Get(string ConnectionId)
        {
            return userStorage[ConnectionId] as IUser;
        }
    }
}