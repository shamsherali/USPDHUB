using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace IOSPush
{
    public class pushnotifications
    {
         public string Id { get; set; }

        [JsonProperty(PropertyName = "userid")]
        public int userid { get; set; }

        [JsonProperty(PropertyName = "profileid")]
        public int profileid { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string message { get; set; }
    }
}



