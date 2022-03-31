using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Services.DiscordService.Models
{
    public class Response
    {
        [JsonProperty("t")]
        public string? Command { get; set; }

        [JsonProperty("s")]
        public object? S { get; set; }

        [JsonProperty("op")]
        public int Op { get; set; }

        [JsonProperty("d")]
        public object Data { get; set; }
    }
}
