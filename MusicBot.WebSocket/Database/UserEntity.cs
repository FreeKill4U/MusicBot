using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.WebSocket.Database
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string? ChannelId { get; set; }
    }
}
