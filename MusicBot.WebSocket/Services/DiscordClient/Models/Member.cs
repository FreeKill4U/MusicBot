using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.WebSocket.Services.DiscordClient.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("public_flags")]
        public int PublicFlags { get; set; }

        [JsonProperty("bot")]
        public bool Bot { get; set; }
    }

    public class Member
    {
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("nick")]
        public string Nick { get; set; }

        [JsonProperty("avatar")]
        public object Avatar { get; set; }

        [JsonProperty("premium_since")]
        public object PremiumSince { get; set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }

        [JsonProperty("is_pending")]
        public bool IsPending { get; set; }

        [JsonProperty("pending")]
        public bool Pending { get; set; }

        [JsonProperty("communication_disabled_until")]
        public object CommunicationDisabledUntil { get; set; }

        [JsonProperty("flags")]
        public int Flags { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("mute")]
        public bool Mute { get; set; }

        [JsonProperty("deaf")]
        public bool Deaf { get; set; }
    }

}
