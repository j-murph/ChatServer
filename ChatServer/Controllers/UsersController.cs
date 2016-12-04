﻿using ChatServer.Models;
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
        [HttpPost]
        public async Task<ApiResult> SendMessage(SendMessageModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ApiResult> GetMessages()
        {
            throw new NotImplementedException();
        }

        #region Models
        public class SendMessageModel
        {
            [Required]
            public string User { get; set; }

            [Required]
            public string Message { get; set; }
        }
        #endregion
    }
}
