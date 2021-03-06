﻿using ChatServer.Services;
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

        public ChannelsController(IChannelService channelService)
        {
            this.channelService = channelService;
        }

        [HttpPost]
        public ApiResult Subscribe(SubscribeModel model)
        {
            if (!Val(model)) return ApiResult.BadRequest;
            channelService.SubscribeUser(model.Channel, model.User);
            return ApiResult.Okay;
        }

        [HttpPost]
        public ApiResult Unsubscribe(UnsubscribeModel model)
        {
            if (!Val(model)) return ApiResult.BadRequest;
            channelService.UnsubscribeUser(model.Channel, model.User);
            return ApiResult.Okay;
        }

        [HttpPost]
        public ApiResult BroadcastMessage(BroadcastMessageModel model)
        {
            if (!Val(model)) return ApiResult.BadRequest;
            var result = channelService.BroadcastMessage(model.Channel, model.User, model.Message);
            if (result == false)
                return ApiResult.FromError("user-not-subscribed");

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
