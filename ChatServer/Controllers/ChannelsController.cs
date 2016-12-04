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
    public class ChannelsController : CSApiControllerBase
    {
        private readonly IChannelService channelService;
        private readonly IMessageService messengerService;

        public ChannelsController(IChannelService channelService, IMessageService messengerService)
        {
            this.channelService = channelService;
            this.messengerService = messengerService;
        }

        [HttpPost]
        public ApiResult Subscribe(SubscribeModel model)
        {
            if (model == null || !ModelState.IsValid)
                return ApiResult.BadRequest;

            channelService.SubscribeUser(model.Channel, model.User);
            return ApiResult.Okay;
        }

        [HttpPost]
        public ApiResult Unsubscribe(UnsubscribeModel model)
        {
            if (model == null || !ModelState.IsValid)
                return ApiResult.BadRequest;

            channelService.UnsubscribeUser(model.Channel, model.User);
            return ApiResult.Okay;
        }

        [HttpPost]
        public ApiResult BroadcastMessage(BroadcastMessageModel model)
        {
            if (model == null || !ModelState.IsValid)
                return ApiResult.BadRequest;

            channelService.BroadcastMessage(model.Channel, model.User, model.Message);
            return ApiResult.Okay;
        }

        #region Models
        public class SubscribeModel
        {
            [Required]
            public string Channel { get; set; }

            [Required]
            public string User { get; set; }
        }

        public class UnsubscribeModel
        {
            [Required]
            public string Channel { get; set; }

            [Required]
            public string User { get; set; }
        }

        public class BroadcastMessageModel
        {
            [Required]
            public string Channel { get; set; }

            [Required]
            public string User { get; set; }

            [Required]
            public string Message { get; set; }
        }
        #endregion
    }
}
