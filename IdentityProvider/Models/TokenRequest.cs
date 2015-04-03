using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace IdentityProvider.Models
{
    [JsonObject]
    public class TokenRequest
    {
        [JsonProperty(Required = Required.Always, PropertyName = "user_id")]
        public string UserId { get; set; }

        [JsonProperty(Required = Required.Always, PropertyName = "password")]
        public string Password { get; set; }
    }
}