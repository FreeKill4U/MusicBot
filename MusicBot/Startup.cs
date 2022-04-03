using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicBot.Core.Database;
using MusicBot.Core.Services.DiscordClient;
using System;
using MusicBot.Core.Services.DiscordClient;
using MusicBot.Core.Services.DiscordService;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(MusicBot.Startup))]

namespace MusicBot
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Transient);
            builder.Services.AddScoped<IDiscordApi, DiscordApi>();
            builder.Services.AddScoped<IResponseService, ResponseService>();
            builder.Services.AddScoped<IDiscordService, DiscordService>();
        }

    }
}
