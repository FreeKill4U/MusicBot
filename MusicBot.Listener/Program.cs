using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MusicBot.Core.Database;

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {

            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Transient);
            services.AddScoped<IDiscordApi, DiscordApi>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IDiscordService, DiscordService>();
        });
}
ext >();