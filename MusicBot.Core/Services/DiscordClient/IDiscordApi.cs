using MusicBot.Core.Services.DiscordService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Services.DiscordClient
{
    public interface IDiscordApi
    {
        Task<List<Channel>> GetChannels(string channelId);
        Task<bool> SendMessege(string content, string channelId);
    }
}
