using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Services.DiscordClient.Models.Request
{
    public class IdentifyPayload : Payload
    {
        [JsonProperty("d")]
        public IdentifyPayloadData Data { get; set; }
    }

    public class Properties
    {
        [JsonProperty("$os")]
        public string Os { get; set; }

        [JsonProperty("$browser")]
        public string Browser { get; set; }

        [JsonProperty("$device")]
        public string Device { get; set; }
    }

    public class IdentifyPayloadData
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("intents")]
        public int Intents { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }
}
