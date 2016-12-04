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
    public class UsersControllerTest
    {
        [TestMethod]
        public void SendMessage()
        {
            IMessageService ms = new MessageService();
            var c = new UsersController(ms);
            var result = c.SendMessage(new UsersController.SendMessageModel
            {
                From = "user 11",
                To = "user 2",
                Message = "!! ## ';~"
            });

        }

        [TestMethod]
        public void GetAllMessages()
        {
            IMessageService ms = new MessageService();
            var c = new UsersController(ms);
            var result = c.GetMessages(new UsersController.GetMessagesModel
            {
                User = "test123"
            });

        }
    }
}
