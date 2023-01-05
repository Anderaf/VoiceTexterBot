using CountTheCharactersBot.Configuration;
using CountTheCharactersBot.Controllers;
using CountTheCharactersBot.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Telegram.Bot;

namespace CountTheCharactersBot
{
    internal class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services))
                .UseConsoleLifetime()
                .Build();

            Console.WriteLine("Сервис запущен");
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();

            services.AddSingleton(BuildAppSettings());
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("5646765494:AAF3AKdoZSD173e7XdrAMhljS7Uzzj3sgyk"));       
            services.AddSingleton<IStorage, MemoryStorage>();

            services.AddHostedService<Bot>();
        }
        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                BotToken = "5885047668:AAERDUQSMDFlM1i8Gek6trH-qxqASxStTr0"
            };
        }
    }
}