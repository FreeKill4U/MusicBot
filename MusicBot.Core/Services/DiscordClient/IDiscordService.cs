using MusicBot.Core.Services.DiscordClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Services.DiscordClient
{
    public interface IDiscordService
    {
        public void Connect(Func<object> func);
        public Task<List<Guild>> GetGuilds();
    }
}
