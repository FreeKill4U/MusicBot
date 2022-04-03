using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Database
{
    public class ChannelEntity
    {
        [Key]
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
    }
}
