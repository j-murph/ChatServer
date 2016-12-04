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
        /// Forwards a message from the specified channel to the specified user.
        /// </summary>
        /// <param name="channel">Channel that received the message.</param>
        /// <param name="to">User receipient.</param>
        /// <param name="message"></param>
        public void ForwardChannelMessage(string channel, string to, string message);
        
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
        ICollection<Message> GetUserMessages(string user);
    }

    public class MessageService : IMessageService
    {
        private readonly ConcurrentDictionary<string, List<Message>> store 
            = new ConcurrentDictionary<string, List<Message>>();

        void IMessageService.ForwardChannelMessage(string channel, string to, string message)
        {
            if (channel == null) throw new ArgumentNullException("channel");
            if (to == null) throw new ArgumentNullException("to");
            if (message == null) throw new ArgumentNullException("message");

            AddMessage(new Message
            {
                Channel = channel,
                To = to,
                MessageText = message
            });
        }

        void IMessageService.SendPrivateMessage(string from, string to, string message)
        {
            if (from == null) throw new ArgumentNullException("from");
            if (to == null) throw new ArgumentNullException("to");
            if (message == null) throw new ArgumentNullException("message");

            AddMessage(new Message
            {
                From = from,
                To = to,
                MessageText = message
            });
        }

        ICollection<Message> IMessageService.GetUserMessages(string user)
        {
            if (user == null) throw new ArgumentNullException("user");

            List<Message> messages;
            if (store.TryGetValue(user, out messages))
            {
                lock(messages)
                {
                    var clone = new List<Message>();
                    clone.AddRange(messages);
                    return clone;
                }
            }
            else
            {
                return new List<Message>();
            }
        }

        private void AddMessage(Message message)
        {
            if (!message.IsValid) throw new ArgumentException("Invalid message.");
            
            var list = store.GetOrAdd(message.To, new List<Message>());
            lock(list)
            {
                list.Add(message);
            }
        }
    }
}