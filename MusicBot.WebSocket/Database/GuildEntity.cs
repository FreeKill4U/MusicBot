using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Database
{
    public class GuildEntity
    {
        [Key]
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public long Owner_id { get; set; }
        public List<ChannelEntity> Channels { get; set; }
        public bool? Is_complete { get; set; }
    }
}
