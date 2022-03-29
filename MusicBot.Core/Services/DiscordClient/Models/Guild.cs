using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Services.DiscordClient.Models
{
    public class Guild
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Icon { get; set; }
        public bool Owner { get; set; }
        public long Permissions { get; set; }
        public List<string> Features { get; set; }
        public string PermissionsNew { get; set; }
    }
}
