using System;
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
        private readonly IUserService userService;

        public ChannelService(IUserService userService)
        {
            this.userService = userService;
        }

        bool IChannelService.SubscribeUser(string channel, string user)
        {
            throw new NotImplementedException();
        }

        bool IChannelService.UnsubscribeUser(string channel, string user)
        {
            throw new NotImplementedException();
        }

        void IChannelService.BroadcastMessage(string channel, string from, string message)
        {
            throw new NotImplementedException();
        }
    }
}