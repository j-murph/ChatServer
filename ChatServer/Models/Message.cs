using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatServer.Models
{
    public class Message
    {
        /// <summary>
        /// The user that sent the message.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// The channel the message was broadcast to. Will be NULL if the message
        /// was sent privately.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// The user the message is addressed to.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The message text.
        /// </summary>
        public string Message { get; set; }
    }
}