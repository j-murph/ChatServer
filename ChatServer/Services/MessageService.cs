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
    public interface IMessageService
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

    public class MessageService : IMessageService
    {
        private readonly ConcurrentDictionary<string, List<Message>> store 
            = new ConcurrentDictionary<string, List<Message>>();

        void IMessageService.SendPrivateMessage(string from, string to, string message)
        {
            throw new NotImplementedException();
        }

        ICollection<Message> IMessageService.GetAllMessages(string user)
        {
            throw new NotImplementedException();
        }

        public void AddMessage(Message message)
        {
            if (!message.IsValid) throw new ArgumentException("message is invalid.");
            var t = store.GetOrAdd(message.To, new List<Message>());
            t.Add(message);
        }

        public ICollection<Message> GetMessagesForUser(string user)
        {
            if (user == null) throw new ArgumentNullException("user");

            List<Message> messages;
            if (store.TryGetValue(user, out messages))
            {
                return messages;
            }
            else
            {
                return new List<Message>();
            }
        }
    }
}