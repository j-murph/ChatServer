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
    public interface IChannelService
    {
        bool SubscribeUser(string channel, string user);
        bool UnsubscribeUser(string channel, string user);

        /// <summary>
        /// Send a message to all users subscribed to the specified channel.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="from">User sending the message.</param>
        /// <param name="message"></param>
        void BroadcastMessage(string channel, string from, string message);
    }

    public class ChannelService : IChannelService
    {
        private readonly IMessageService messageService;

        private readonly ConcurrentDictionary<string, List<string>> store
            = new ConcurrentDictionary<string, List<string>>();

        public ChannelService(IMessageService userService)
        {
            this.messageService = userService;
        }

        /// <summary>
        /// Register a user to receive messages sent to the specified channel.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="user"></param>
        /// <returns>False if the user is already registered.</returns>
        bool IChannelService.SubscribeUser(string channel, string user)
        {
            if (channel == null) throw new ArgumentNullException("channel");
            if (user == null) throw new ArgumentNullException("user");

            var channelList = store.GetOrAdd(channel, new List<string>());
            lock(channelList)
            {
                if (!channelList.Where(u => u == user).Any())
                {
                    channelList.Add(user);
                    return true;
                }
            }

            return false;
        }

        bool IChannelService.UnsubscribeUser(string channel, string user)
        {
            if (channel == null) throw new ArgumentNullException("channel");
            if (user == null) throw new ArgumentNullException("user");

            var channelList = store.GetOrAdd(channel, new List<string>());
            lock (channelList)
            {
                return channelList.Remove(user);
            }
        }

        void IChannelService.BroadcastMessage(string channel, string from, string message)
        {
            if (channel == null) throw new ArgumentNullException("channel");
            if (from == null) throw new ArgumentNullException("from");
            if (message == null) throw new ArgumentNullException("message");

            var channelList = store.GetOrAdd(channel, new List<string>());
            lock (channelList)
            {
                var now = DateTime.UtcNow;
                
                foreach(var user in channelList)
                {
                    var msg = new Message
                    {
                        Channel = channel,
                        From = from,
                        MessageText = message,
                        To = user,
                        Timestamp = now
                    };

                    messageService.SendMessage(msg);
                }
            }
        }
    }
}