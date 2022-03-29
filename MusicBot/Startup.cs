using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicBot.Core.Database;
using MusicBot.Core.Services.DiscordClient;
using System;
using MusicBot.Core.Services.DiscordClient;

[assembly: FunctionsStartup(typeof(MusicBot.Startup))]

namespace MusicBot
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.AddScoped<IDiscordService, DiscordService>();
        }

    }
}
