using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using MusicBot.Core.Database;
using MusicBot.Core.Services.DiscordClient;

namespace MusicBot
{
    public class Function1
    {
        private readonly ApplicationDbContext _context;
        private readonly IDiscordService _discord;

        public Function1(ApplicationDbContext context, IDiscordService discord)
        {
            _context = context;
            _discord = discord;
        }
        [FunctionName("Function1")]
        public void Run([TimerTrigger("* * * */2 * *", RunOnStartup = true)] TimerInfo myTimer, ILogger log)
        {
            //_discord.UseLogger(log);
        }
    }
}
