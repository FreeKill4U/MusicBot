using Microsoft.Extensions.DependencyInjection;
using MusicBot.Core;

public class Program
{
    public static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();

        Startup startup = new Startup();
        startup.ConfigureServices(services);
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        serviceProvider
            .GetService<ILoggerFactory>()
            .AddConsole(LogLevel.Debug);

        var logger = serviceProvider.GetService<ILoggerFactory>()
            .CreateLogger<Program>();

        logger.LogDebug("Logger is working!");

        var service = serviceProvider.GetService<IMyService>();
        service.MyServiceMethod();
    }
}