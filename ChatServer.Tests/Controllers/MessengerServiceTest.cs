using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatServer;
using ChatServer.Services;

namespace ChatServer.Tests.Controllers
{
    [TestClass]
    public class MessengerServiceTest
    {
        [TestMethod]
        public void BroadcastToChannel()
        {
            IMessageService ms = new MessageService();
            ms.BroadcastToChannel("testchannel", "testuser", "test message.");
        }

        [TestMethod]
        public void SendPrivateMessage()
        {
            IMessageService ms = new MessageService();
            ms.SendPrivateMessage("testuser1", "testuser2", "test message.");
        }

        [TestMethod]
        public void GetAllMessages()
        {
            IMessageService ms = new MessageService();
            ms.GetAllMessages("testuser");
        }
    }
}
