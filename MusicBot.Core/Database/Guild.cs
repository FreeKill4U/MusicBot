using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Database
{
    public class Guild
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string? Icon { get; set; }
        public bool Owner { get; set; }
        public int Permissions { get; set; }
        public string? Permissions_new { get; set; }
    }

}
