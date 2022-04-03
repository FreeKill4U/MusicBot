using Microsoft.Extensions.Logging;
using MusicBot.Core.Services.DiscordClient;
using System;

namespace MusicBot
{
    public class EntryPoint
    {
        private readonly ILogger<EntryPoint> log;
        private readonly IDiscordService _service;

        public EntryPoint(ILogger<EntryPoint> logger, IDiscordService service)
        {
            log = logger;
        }
        public void Run()
        {
            _service.UseLogger(log);
            _service.Connect();
        }
    }
}