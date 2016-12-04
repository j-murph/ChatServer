using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

        /// <summary>
        /// When the message was received, UTC time.
        /// </summary>
        public DateTime Timestamp { get; set; }

        [IgnoreDataMember]  // Prevent this from being serialized to XML/JSON.
        public bool IsValid
        {
            // TODO: Maybe move this into a validation class as an extension method to keep models POD'like.
            get
            {
                if (From == null) return false; // No sender.
                if (To == null) return false; // No recipient.
                return MessageText != null && Timestamp != default(DateTime);
            }
        }
    }
}