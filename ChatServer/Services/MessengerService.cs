using ChatServer.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatServer.Services
{
    /// <summary>
    /// Derived implementations should be thread-safe.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Send a message to a specific user.
        /// </summary>
        /// <param name="from">User sending the message.</param>
        /// <param name="to">Recpient user.</param>
        /// <param name="message"></param>
        void SendPrivateMessage(string from, string to, string message);

        /// <summary>
        /// Retrieves all messages for the user. This includes messages sent
        /// to channels the user is subscribed to and private messages.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        ICollection<Message> GetAllMessages(string user);
    }

    public class UserService : IUserService
    {
        private readonly IMessageStoreService messageStore;

        public UserService(IMessageStoreService messageStore)
        {
            this.messageStore = messageStore;
        }

        void IUserService.SendPrivateMessage(string from, string to, string message)
        {
            throw new NotImplementedException();
        }


        ICollection<Message> IUserService.GetAllMessages(string user)
        {
            throw new NotImplementedException();
        }
    }
}