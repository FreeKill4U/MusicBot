using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Services.DiscordService.Models
{
    public class UserSettings
    {
    }

    public class UserData
    {
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("mfa_enabled")]
        public bool MfaEnabled { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("flags")]
        public int Flags { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("bot")]
        public bool Bot { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }

    public class Guild
    {
        [JsonProperty("unavailable")]
        public bool Unavailable { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Application
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("flags")]
        public int Flags { get; set; }
    }

    public class Ready
    {
        [JsonProperty("v")]
        public int V { get; set; }

        [JsonProperty("user_settings")]
        public UserSettings UserSettings { get; set; }

        [JsonProperty("user")]
        public UserData User { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("relationships")]
        public List<object> Relationships { get; set; }

        [JsonProperty("private_channels")]
        public List<object> PrivateChannels { get; set; }

        [JsonProperty("presences")]
        public List<object> Presences { get; set; }

        [JsonProperty("guilds")]
        public List<Guild> Guilds { get; set; }

        [JsonProperty("guild_join_requests")]
        public List<object> GuildJoinRequests { get; set; }

        [JsonProperty("geo_ordered_rtc_regions")]
        public List<string> GeoOrderedRtcRegions { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }

        [JsonProperty("_trace")]
        public List<string> Trace { get; set; }
    }

    public class ReadyResponse
    {
        [JsonProperty("t")]
        public string T { get; set; }

        [JsonProperty("s")]
        public int S { get; set; }

        [JsonProperty("op")]
        public int Op { get; set; }

        [JsonProperty("d")]
        public Ready Data { get; set; }
    }


}
