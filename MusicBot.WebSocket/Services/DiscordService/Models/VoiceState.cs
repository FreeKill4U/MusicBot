using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.WebSocket.Services.DiscordService.Models
{
    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("avatar")]
        public object Avatar { get; set; }
    }

    public class VoiceState
    {
        [JsonProperty("member")]
        public Member Member { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("suppress")]
        public bool Suppress { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("self_video")]
        public bool SelfVideo { get; set; }

        [JsonProperty("self_mute")]
        public bool SelfMute { get; set; }

        [JsonProperty("self_deaf")]
        public bool SelfDeaf { get; set; }

        [JsonProperty("request_to_speak_timestamp")]
        public object RequestToSpeakTimestamp { get; set; }

        [JsonProperty("mute")]
        public bool Mute { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("deaf")]
        public bool Deaf { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }

    public class VoiceStateResponse
    {
        [JsonProperty("t")]
        public string T { get; set; }

        [JsonProperty("s")]
        public int S { get; set; }

        [JsonProperty("op")]
        public int Op { get; set; }

        [JsonProperty("d")]
        public VoiceState Data { get; set; }
    }
}
