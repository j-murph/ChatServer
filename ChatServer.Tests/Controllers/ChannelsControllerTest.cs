using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatServer;
using ChatServer.Services;
using ChatServer.Controllers;

namespace ChatServer.Tests.Controllers
{
    [TestClass]
    public class ChannelsControllerTest
    {
        [TestMethod]
        public void Subscribe()
        {
            IMessageService ms = new MessageService();
            IChannelService cs = new ChannelService(ms);
            var c = new ChannelsController(cs);
            var result = c.Subscribe(new ChannelsController.SubscribeModel
            {
                Channel = "test channel",
                User = "test user 123 $$$"
            });

            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void Unsubscribe()
        {
            IMessageService ms = new MessageService();
            IChannelService cs = new ChannelService(ms);
            var c = new ChannelsController(cs);

            // Shouldn't error if the user is already unsubscribed.
            var result = c.Unsubscribe(new ChannelsController.UnsubscribeModel
            {
                Channel = "test channel",
                User = "test user 123 $$$"
            });

            Assert.AreEqual(true, result.Success);
            
            result = c.Subscribe(new ChannelsController.SubscribeModel
            {
                Channel = "test channel",
                User = "test user 123 $$$"
            });

            Assert.AreEqual(true, result.Success);

            // User is subscribed now.
            result = c.Unsubscribe(new ChannelsController.UnsubscribeModel
            {
                Channel = "test channel",
                User = "test user 123 $$$"
            });

            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void BroadcastMessage()
        {
            IMessageService ms = new MessageService();
            IChannelService cs = new ChannelService(ms);
            var c = new ChannelsController(cs);
            var result = c.BroadcastMessage(new ChannelsController.BroadcastMessageModel
            {
                Channel = "test channel 123",
                Message = "This is a message!",
                User = "! @ # $ % ^ & * ( )"
            });

            Assert.AreEqual(true, result.Success);
        }
    }
}
