using Microsoft.Extensions.Logging;
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
        public void Connect();
        public void Identify();
        public void UseLogger(ILogger logger);
    }
}
