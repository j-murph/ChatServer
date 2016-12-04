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
    public interface IMessengerService
    {
        /// <summary>
        /// Send a message to all users subscribed to the specified channel.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="from">User sending the message.</param>
        /// <param name="message"></param>
        void BroadcastToChannel(string channel, string from, string message);

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

    public class MessengerService : IMessengerService
    {
        private readonly IMessageStoreService messageStore;

        public MessengerService(IMessageStoreService messageStore)
        {
            this.messageStore = messageStore;
        }

        void IMessengerService.BroadcastToChannel(string channel, string user, string message)
        {
            throw new NotImplementedException();
        }

        void IMessengerService.SendPrivateMessage(string from, string to, string message)
        {
            throw new NotImplementedException();
        }


        ICollection<Message> IMessengerService.GetAllMessages(string user)
        {
            throw new NotImplementedException();
        }
    }
}