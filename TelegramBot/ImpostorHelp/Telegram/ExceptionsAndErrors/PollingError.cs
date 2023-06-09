using Telegram.Bot;
using Telegram.Bot.Exceptions;

namespace ImpostorHelp.Telegram.ExceptionsAndErrors;

public static class PollingError
{
    public static Task PollingErrorHandlerAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}