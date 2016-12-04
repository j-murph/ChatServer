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
        public string MessageText { get; set; }

        public bool IsValid
        {
            // TODO: Maybe move this into a validation class as an extension method to keep models POD'like.
            get
            {
                if (From == null) return false;
                if (Channel != null && To != null) return false; // Multiple recipients.
                if (Channel == null || To == null) return false; // No recipients.
                return MessageText != null;
            }
        }
    }
}