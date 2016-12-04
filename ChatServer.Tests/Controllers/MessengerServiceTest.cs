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
            IUserService ms = new UserService();
            ms.BroadcastToChannel("testchannel", "testuser", "test message.");
        }

        [TestMethod]
        public void SendPrivateMessage()
        {
            IUserService ms = new UserService();
            ms.SendPrivateMessage("testuser1", "testuser2", "test message.");
        }

        [TestMethod]
        public void GetAllMessages()
        {
            IUserService ms = new UserService();
            ms.GetAllMessages("testuser");
        }
    }
}
