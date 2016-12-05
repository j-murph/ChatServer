using ChatServer.Models;
using ChatServer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChatServer.Controllers
{
    public class UsersController : CSApiControllerBase
    {
        private readonly IMessageService messengerService;

        public UsersController(IMessageService messengerService)
        {
            this.messengerService = messengerService;
        }

        [HttpPost]
        public ApiResult SendMessage(SendMessageModel model)
        {
            if (!Val(model)) return ApiResult.BadRequest;
            messengerService.SendPrivateMessage(model.From, model.To, model.Message);
            return ApiResult.Okay;
        }

        [HttpPost]
        public ApiResult GetMessages(GetMessagesModel model)
        {
            if (!Val(model)) return ApiResult.BadRequest;
            var messages = messengerService.GetUserMessages(model.User);
            return ApiResult.FromSuccess(messages);
        }

        #region Models
        public class SendMessageModel
        {
            [Required]
            public string From { get; set; }

            [Required]
            public string To { get; set; }

            [Required]
            public string Message { get; set; }
        }

        public class GetMessagesModel
        {
            [Required]
            public string User { get; set; }
        }
        #endregion
    }
}
