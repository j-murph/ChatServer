﻿using System;
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
        [HttpPost]
        public async Task<ApiResult> Subscribe(SubscribeModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ApiResult> Unsubscribe(UnsubscribeModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ApiResult> BroadcastMessage(BroadcastMessageModel model)
        {
            throw new NotImplementedException();
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
