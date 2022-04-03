using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.WebSocket.Services.DiscordService.Models
{
    public class Member
    {
        [JsonProperty("roles")]
        public List<object> Roles { get; set; }

        [JsonProperty("mute")]
        public bool Mute { get; set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }

        [JsonProperty("hoisted_role")]
        public object HoistedRole { get; set; }

        [JsonProperty("flags")]
        public int Flags { get; set; }

        [JsonProperty("deaf")]
        public bool Deaf { get; set; }
    }

    public class Author
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("public_flags")]
        public int PublicFlags { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("avatar")]
        public object Avatar { get; set; }
    }

    public class MessegeCreate
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("tts")]
        public bool Tts { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("referenced_message")]
        public object ReferencedMessage { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("mentions")]
        public List<object> Mentions { get; set; }

        [JsonProperty("mention_roles")]
        public List<object> MentionRoles { get; set; }

        [JsonProperty("mention_everyone")]
        public bool MentionEveryone { get; set; }

        [JsonProperty("member")]
        public Member Member { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("flags")]
        public int Flags { get; set; }

        [JsonProperty("embeds")]
        public List<object> Embeds { get; set; }

        [JsonProperty("edited_timestamp")]
        public object EditedTimestamp { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("components")]
        public List<object> Components { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("attachments")]
        public List<object> Attachments { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
    }

    public class MessegeCreateResponse
    {
        [JsonProperty("t")]
        public string T { get; set; }

        [JsonProperty("s")]
        public int S { get; set; }

        [JsonProperty("op")]
        public int Op { get; set; }

        [JsonProperty("d")]
        public MessegeCreate Data { get; set; }
    }

}
