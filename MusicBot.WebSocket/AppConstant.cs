using MusicBot.Core.Services.DiscordService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core
{
    public static class AppConstant
    {
        public const string DiscordUrl = "https://discord.com/api/v9";
        public const string DiscordToken = "OTU3NjY3NjQzMDA2MDAxMTky.YkCHfg.0Cnpw50J2eodkR07BdomCy1RBAs";
        public const string BotName = "Liber";
    }

    public class Statistics
    {
        public int Version { get; set; }
        public string Session_id { get; set; }
        public UserData Bot { get; set; }
        public bool IsReady { get; set; }
    }
}
