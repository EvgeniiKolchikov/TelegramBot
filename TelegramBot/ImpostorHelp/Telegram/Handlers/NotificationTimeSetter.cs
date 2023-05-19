using System.Text.RegularExpressions;
using ImpostorHelp.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Handlers;

public class NotificationTimeSetter
{
    private ChatRepository _chatRepository;
    private string _regexTemplate = @"^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$";
    public NotificationTimeSetter()
    {
        _chatRepository = new ChatRepository();
    }

    public async Task MessageBeforeTimeChange(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Введите время в формате \"Время.00:00\"",
            cancellationToken: cancellationToken
        );
    }
    public async Task SetNotificationTimeFromCallBack(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var data = update.CallbackQuery.Data;
        var length = data.Length;
        var time = data.Substring(length - 5, 5);
        if (Regex.Match(time,_regexTemplate).Success)
        {
            await _chatRepository.AddNotificationTimeAsync(update.CallbackQuery.From.Id, TimeOnly.Parse(time));
            
            await botClient.SendTextMessageAsync(
                chatId: update.CallbackQuery.From.Id,
                text: "Сохранено " + time,
                cancellationToken: cancellationToken
            );
        }
    }

    public async Task SetNotificationTimeFromText(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var data = update.Message.Text;
        var time = data.Substring(data.Length - 5, 5);
        if (Regex.Match(time,_regexTemplate).Success)
        {
            await _chatRepository.AddNotificationTimeAsync(update.Message.Chat.Id, TimeOnly.Parse(time));
            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: $"Сохранено {time}",
                cancellationToken: cancellationToken
            );
        }

    }
}