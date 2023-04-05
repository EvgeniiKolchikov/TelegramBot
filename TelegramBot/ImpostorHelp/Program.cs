using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using ImpostorHelp.Telegram;
using ImpostorHelp.Telegram.Controllers;
using ImpostorHelp.Telegram.Controllers.ExceptionsAndErrors;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

try
{
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    var config = builder.Build();
    
    var botController = new BotController();
    
    var botToken = config["Token"] ?? throw new Exception("токен отсутствует");
    var botClient = new TelegramBotClient(botToken);

    using CancellationTokenSource cts = new();

    ReceiverOptions receiverOptions = new()
    {
        AllowedUpdates = Array.Empty<UpdateType>()
    };

    botClient.StartReceiving(
        updateHandler: botController.Run,
        pollingErrorHandler: PollingError.PollingErrorHandlerAsync,
        receiverOptions: receiverOptions,
        cancellationToken: cts.Token
    );

    var me = await botClient.GetMeAsync();
    Console.WriteLine($"Start listening for @{me.Username}");
    Console.ReadLine();

    cts.Cancel();

    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
