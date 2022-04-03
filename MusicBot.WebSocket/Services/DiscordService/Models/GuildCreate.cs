using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicBot.Core.Services.DiscordService.Models
{
    public class Tags
    {
        [JsonProperty("bot_id")]
        public string BotId { get; set; }
    }

    public class Role
    {
        [JsonProperty("unicode_emoji")]
        public object UnicodeEmoji { get; set; }

        [JsonProperty("tags")]
        public Tags Tags { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("permissions")]
        public string Permissions { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mentionable")]
        public bool Mentionable { get; set; }

        [JsonProperty("managed")]
        public bool Managed { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("icon")]
        public object Icon { get; set; }

        [JsonProperty("hoist")]
        public bool Hoist { get; set; }

        [JsonProperty("color")]
        public int Color { get; set; }
    }

    public class ApplicationCommandCounts
    {
        [JsonProperty("3")]
        public int _3 { get; set; }

        [JsonProperty("2")]
        public int _2 { get; set; }

        [JsonProperty("1")]
        public int _1 { get; set; }
    }

    public class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("permission_overwrites")]
        public List<object> PermissionOverwrites { get; set; }

        [JsonProperty("rate_limit_per_user")]
        public int RateLimitPerUser { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("last_message_id")]
        public string LastMessageId { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("default_auto_archive_duration")]
        public int DefaultAutoArchiveDuration { get; set; }
    }

    public class Metadata
    {
        [JsonProperty("omitted")]
        public bool Omitted { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }

    public class GuildHashes
    {
        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("roles")]
        public Metadata Roles { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("channels")]
        public Metadata Channels { get; set; }
    }

    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("bot")]
        public bool Bot { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }

    public class Member
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("mute")]
        public bool Mute { get; set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }

        [JsonProperty("hoisted_role")]
        public object HoistedRole { get; set; }

        [JsonProperty("deaf")]
        public bool Deaf { get; set; }
    }

    public class GuildCreate
    {
        [JsonProperty("verification_level")]
        public int VerificationLevel { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("banner")]
        public object Banner { get; set; }

        [JsonProperty("max_video_channel_users")]
        public int MaxVideoChannelUsers { get; set; }

        [JsonProperty("stage_instances")]
        public List<object> StageInstances { get; set; }

        [JsonProperty("rules_channel_id")]
        public object RulesChannelId { get; set; }

        [JsonProperty("application_id")]
        public object ApplicationId { get; set; }

        [JsonProperty("roles")]
        public List<Role> Roles { get; set; }

        [JsonProperty("default_message_notifications")]
        public int DefaultMessageNotifications { get; set; }

        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        [JsonProperty("application_command_counts")]
        public ApplicationCommandCounts ApplicationCommandCounts { get; set; }

        [JsonProperty("mfa_level")]
        public int MfaLevel { get; set; }

        [JsonProperty("discovery_splash")]
        public object DiscoverySplash { get; set; }

        [JsonProperty("premium_subscription_count")]
        public int PremiumSubscriptionCount { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("lazy")]
        public bool Lazy { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }

        [JsonProperty("guild_hashes")]
        public GuildHashes GuildHashes { get; set; }

        [JsonProperty("unavailable")]
        public bool Unavailable { get; set; }

        [JsonProperty("preferred_locale")]
        public string PreferredLocale { get; set; }

        [JsonProperty("nsfw_level")]
        public int NsfwLevel { get; set; }

        [JsonProperty("presences")]
        public List<object> Presences { get; set; }

        [JsonProperty("stickers")]
        public List<object> Stickers { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("afk_timeout")]
        public int AfkTimeout { get; set; }

        [JsonProperty("application_command_count")]
        public int ApplicationCommandCount { get; set; }

        [JsonProperty("premium_progress_bar_enabled")]
        public bool PremiumProgressBarEnabled { get; set; }

        [JsonProperty("threads")]
        public List<object> Threads { get; set; }

        [JsonProperty("public_updates_channel_id")]
        public object PublicUpdatesChannelId { get; set; }

        [JsonProperty("splash")]
        public object Splash { get; set; }

        [JsonProperty("guild_scheduled_events")]
        public List<object> GuildScheduledEvents { get; set; }

        [JsonProperty("large")]
        public bool Large { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("premium_tier")]
        public int PremiumTier { get; set; }

        [JsonProperty("explicit_content_filter")]
        public int ExplicitContentFilter { get; set; }

        [JsonProperty("members")]
        public List<Member> Members { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("embedded_activities")]
        public List<object> EmbeddedActivities { get; set; }

        [JsonProperty("system_channel_flags")]
        public int SystemChannelFlags { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("voice_states")]
        public List<object> VoiceStates { get; set; }

        [JsonProperty("emojis")]
        public List<object> Emojis { get; set; }

        [JsonProperty("features")]
        public List<object> Features { get; set; }

        [JsonProperty("system_channel_id")]
        public string SystemChannelId { get; set; }

        [JsonProperty("afk_channel_id")]
        public object AfkChannelId { get; set; }

        [JsonProperty("vanity_url_code")]
        public object VanityUrlCode { get; set; }

        [JsonProperty("max_members")]
        public int MaxMembers { get; set; }

        [JsonProperty("hub_type")]
        public object HubType { get; set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }
    }

    public class GuildCreateResponse
    {
        [JsonProperty("t")]
        public string T { get; set; }

        [JsonProperty("s")]
        public int S { get; set; }

        [JsonProperty("op")]
        public int Op { get; set; }

        [JsonProperty("d")]
        public GuildCreate Data { get; set; }
    }


}
