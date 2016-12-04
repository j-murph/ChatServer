using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatServer;
using ChatServer.Controllers;
using ChatServer.Services;
using System.Linq;

namespace ChatServer.Tests.Controllers
{
    [TestClass]
    public class ChannelServiceTest
    {
        [TestMethod]
        public void SubscribeUser()
        {
            IMessageService ms = new MessageService();
            IChannelService cs = new ChannelService(ms);

            cs.SubscribeUser("testchannel", "testuser");
            cs.BroadcastMessage("testchannel", "testuser", "valid message");
            var messages = ms.GetUserMessages("testuser");

            Assert.AreEqual("valid message", messages.First().MessageText);
        }

        [TestMethod]
        public void UnsubscribUser()
        {
            IMessageService ms = new MessageService();
            IChannelService cs = new ChannelService(ms);

            cs.SubscribeUser("testchannel", "testuser");
            cs.BroadcastMessage("testchannel", "testuser", "valid message");
            var messages = ms.GetUserMessages("testuser");

            Assert.AreEqual(1, messages.Count());


            cs.UnsubscribeUser("testchannel", "testuser");
            cs.BroadcastMessage("testchannel", "testuser", "valid message");
            messages = ms.GetUserMessages("testuser");

            Assert.AreEqual(1, messages.Count());
        }

        [TestMethod]
        public void SubscribeUnsubscribeUser()
        {
            IMessageService ms = new MessageService();
            IChannelService cs = new ChannelService(ms);

            cs.SubscribeUser("testchannel", "testuser");
            cs.UnsubscribeUser("testchannel", "testuser");
            cs.BroadcastMessage("testchannel", "whocares?", "valid message");
            var messages = ms.GetUserMessages("testuser");

            Assert.AreEqual(0, messages.Count());
        }
    }
}
