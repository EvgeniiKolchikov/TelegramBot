using ImpostorHelp;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

var botToken = ConfigurationHelper.GetStringFromConfigurationFile("Token");
var botController = new BotController();

var botClient = new TelegramBotClient(botToken){Timeout = TimeSpan.FromSeconds(10)};

using CancellationTokenSource cts = new();

ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>()
};

botClient.StartReceiving(
    updateHandler: botController.DialogControl,
    pollingErrorHandler: PollingError.PollingErrorHandlerAsync,
    receiverOptions : receiverOptions,
    cancellationToken: cts.Token
    );

var me = await botClient.GetMeAsync();
Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

cts.Cancel();

