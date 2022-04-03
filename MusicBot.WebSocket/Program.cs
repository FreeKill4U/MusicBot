using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using MusicBot.Core.Database;
using MusicBot.Core.Services.DiscordClient;
using MusicBot.Core.Services.DiscordService;

namespace MusicBot
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var app = serviceProvider.GetService<DiscordService>();
            app.Connect();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Add Logger
            services.AddLogging(configure => configure.AddSimpleConsole(options =>
            {
                options.IncludeScopes = true;
                options.SingleLine = true;
                options.ColorBehavior = (LoggerColorBehavior)ConsoleColor.Yellow;
            }));

            // Register Application
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IDiscordApi, DiscordApi>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddTransient<DiscordService>();
        }
    }
}