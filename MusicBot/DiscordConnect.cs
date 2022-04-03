using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MusicBot.Core.Database;
using MusicBot.Core.Services.DiscordClient;

namespace MusicBot
{
    public class DiscordConnect
    {
        private readonly ApplicationDbContext _context;
        private readonly IDiscordService _discord;

        public DiscordConnect(ApplicationDbContext context, IDiscordService discord)
        {
            _context = context;
            _discord = discord;
        }

        [FunctionName("DiscordConnect")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            _discord.UseLogger(log);
            return new OkObjectResult("");
        }
    }
}
