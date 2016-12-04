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
    public class MessageServiceTest
    {
        [TestMethod]
        public void SendPrivateMessage()
        {
            IMessageService ms = new MessageService();
            ms.SendPrivateMessage("testuser1", "testuser", "valid message");
            var messages = ms.GetUserMessages("testuser");

            Assert.AreEqual("valid message", messages.First().MessageText);
        }

        [TestMethod]
        public void GetAllMessages()
        {
            IMessageService ms = new MessageService();
            ms.SendPrivateMessage("testuser1", "testuser", "valid message");
            ms.SendPrivateMessage("testuser1", "otheruser", "test message.");
            ms.SendPrivateMessage("otheruser", "otheruser", "test message.");
            ms.SendPrivateMessage("otheruser", "testuser", "valid message");
            var messages = ms.GetUserMessages("testuser");
            
            Assert.AreEqual(2, messages.Count());
            Assert.AreEqual("valid message", messages.First().MessageText);
        }
    }
}
