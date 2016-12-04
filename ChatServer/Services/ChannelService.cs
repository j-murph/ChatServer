using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatServer.Services
{
    public interface IChannelService
    {
        bool SubscribeUser(string channel, string user);
        bool UnsubscribeUser(string channel, string user);
    }

    public class ChannelService : IChannelService
    {

        bool IChannelService.SubscribeUser(string channel, string user)
        {
            throw new NotImplementedException();
        }

        bool IChannelService.UnsubscribeUser(string channel, string user)
        {
            throw new NotImplementedException();
        }
    }
}