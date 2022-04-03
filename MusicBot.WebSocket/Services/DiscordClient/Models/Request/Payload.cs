using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Services.DiscordClient.Models.Request
{
    public abstract class Payload
    {
        [JsonProperty("op")]
        public int Op { get; set; }

        [JsonProperty("d")]
        
        public object Data { get; set; }
    }
}
