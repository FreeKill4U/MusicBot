using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicBot.Core.Services.DiscordService.Models
{
    public class Channel
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("permission_overwrites")]
        public List<object> PermissionOverwrites { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("topic")]
        public object Topic { get; set; }

        [JsonProperty("rate_limit_per_user")]
        public int? RateLimitPerUser { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("last_pin_timestamp")]
        public DateTime? LastPinTimestamp { get; set; }

        [JsonProperty("last_message_id")]
        public string LastMessageId { get; set; }

        [JsonProperty("user_limit")]
        public int? UserLimit { get; set; }

        [JsonProperty("rtc_region")]
        public object RtcRegion { get; set; }

        [JsonProperty("bitrate")]
        public int? Bitrate { get; set; }

        [JsonProperty("omitted")]
        public bool Omitted { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }

    public class Roles
    {
        [JsonProperty("omitted")]
        public bool Omitted { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

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
        public Roles Roles { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }
    }

    public class VoiceState
    {
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

        [JsonProperty("deaf")]
        public bool Deaf { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
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

    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("bot")]
        public bool? Bot { get; set; }
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
        public string HoistedRole { get; set; }

        [JsonProperty("deaf")]
        public bool Deaf { get; set; }

        [JsonProperty("premium_since")]
        public object PremiumSince { get; set; }

        [JsonProperty("pending")]
        public bool? Pending { get; set; }

        [JsonProperty("nick")]
        public object Nick { get; set; }

        [JsonProperty("communication_disabled_until")]
        public object CommunicationDisabledUntil { get; set; }

        [JsonProperty("avatar")]
        public object Avatar { get; set; }
    }

    public class Tags
    {
        [JsonProperty("bot_id")]
        public string BotId { get; set; }
    }

    public class GuildCreate
    {
        [JsonProperty("stickers")]
        public List<object> Stickers { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }

        [JsonProperty("large")]
        public bool Large { get; set; }

        [JsonProperty("public_updates_channel_id")]
        public object PublicUpdatesChannelId { get; set; }

        [JsonProperty("hub_type")]
        public object HubType { get; set; }

        [JsonProperty("vanity_url_code")]
        public object VanityUrlCode { get; set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }

        [JsonProperty("guild_hashes")]
        public GuildHashes GuildHashes { get; set; }

        [JsonProperty("embedded_activities")]
        public List<object> EmbeddedActivities { get; set; }

        [JsonProperty("verification_level")]
        public int VerificationLevel { get; set; }

        [JsonProperty("premium_progress_bar_enabled")]
        public bool PremiumProgressBarEnabled { get; set; }

        [JsonProperty("explicit_content_filter")]
        public int ExplicitContentFilter { get; set; }

        [JsonProperty("max_video_channel_users")]
        public int MaxVideoChannelUsers { get; set; }

        [JsonProperty("rules_channel_id")]
        public object RulesChannelId { get; set; }

        [JsonProperty("application_command_count")]
        public int ApplicationCommandCount { get; set; }

        [JsonProperty("features")]
        public List<string> Features { get; set; }

        [JsonProperty("system_channel_id")]
        public string SystemChannelId { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("splash")]
        public object Splash { get; set; }

        [JsonProperty("discovery_splash")]
        public object DiscoverySplash { get; set; }

        [JsonProperty("stage_instances")]
        public List<object> StageInstances { get; set; }

        [JsonProperty("application_id")]
        public object ApplicationId { get; set; }

        [JsonProperty("icon")]
        public object Icon { get; set; }

        [JsonProperty("voice_states")]
        public List<VoiceState> VoiceStates { get; set; }

        [JsonProperty("lazy")]
        public bool Lazy { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("afk_channel_id")]
        public object AfkChannelId { get; set; }

        [JsonProperty("application_command_counts")]
        public ApplicationCommandCounts ApplicationCommandCounts { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("threads")]
        public List<object> Threads { get; set; }

        [JsonProperty("unavailable")]
        public bool Unavailable { get; set; }

        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("preferred_locale")]
        public string PreferredLocale { get; set; }

        [JsonProperty("system_channel_flags")]
        public int SystemChannelFlags { get; set; }

        [JsonProperty("nsfw_level")]
        public int NsfwLevel { get; set; }

        [JsonProperty("presences")]
        public List<object> Presences { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("default_message_notifications")]
        public int DefaultMessageNotifications { get; set; }

        [JsonProperty("mfa_level")]
        public int MfaLevel { get; set; }

        [JsonProperty("members")]
        public List<Member> Members { get; set; }

        [JsonProperty("guild_scheduled_events")]
        public List<object> GuildScheduledEvents { get; set; }

        [JsonProperty("banner")]
        public object Banner { get; set; }

        [JsonProperty("premium_subscription_count")]
        public int PremiumSubscriptionCount { get; set; }

        [JsonProperty("premium_tier")]
        public int PremiumTier { get; set; }

        [JsonProperty("afk_timeout")]
        public int AfkTimeout { get; set; }

        [JsonProperty("roles")]
        public List<Roles> Roles { get; set; }

        [JsonProperty("emojis")]
        public List<object> Emojis { get; set; }

        [JsonProperty("max_members")]
        public int MaxMembers { get; set; }
    }



}
