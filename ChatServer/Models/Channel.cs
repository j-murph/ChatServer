using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatServer.Models
{
    public class Channel
    {
        public string Name { get; set; }

        public ConcurrentDictionary<string, object> RegisteredUsers { get; set; }

        public Channel()
        {
            RegisteredUsers = new ConcurrentDictionary<string, object>();
        }
    }
}