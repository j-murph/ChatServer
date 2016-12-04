using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatServer;
using ChatServer.Controllers;
using ChatServer.Services;

namespace ChatServer.Tests.Controllers
{
    [TestClass]
    public class ChannelServiceTest
    {
        [TestMethod]
        public void SubscribeUser()
        {
            IChannelService cs = new ChannelService();
            cs.SubscribeUser("testchannel", "testuser");
        }

        [TestMethod]
        public void UnsubscribUser()
        {
            IChannelService cs = new ChannelService();
            cs.UnsubscribeUser("testchannel", "testuser");
        }

        [TestMethod]
        public void SubscribeUnsubscribeUser()
        {
            IChannelService cs = new ChannelService();
            cs.SubscribeUser("testchannel", "testuser");
            cs.UnsubscribeUser("testchannel", "testuser");
        }
    }
}
