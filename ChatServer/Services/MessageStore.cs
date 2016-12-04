using ChatServer.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatServer.Services
{
    /// <summary>
    /// Derived implementations should be thread safe.
    /// </summary>
    public interface IMessageStoreService
    {
        void AddMessage(Message message);
        void GetMessagesForUser(string user);
    }

    public class MessageStoreService : IMessageStoreService
    {
        private readonly ConcurrentDictionary<string, List<Message>> store = new ConcurrentDictionary<string, List<Message>>();

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