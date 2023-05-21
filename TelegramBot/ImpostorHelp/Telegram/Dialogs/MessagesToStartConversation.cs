using ImpostorHelp.Telegram.StaticClasses;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Dialogs;

public class MessagesToStartConversation
{
    public async Task DailyTextDialog(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;
        Console.WriteLine($"Received a '{update.Message.Text}' message in chat {update.Message.From.Username}.");
        var welcomeMessage = "Привет! Поделись, как ты себя ощущаешь сегодня? Скорее как самозванец или как умница?";
        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: welcomeMessage,
            cancellationToken: cancellationToken,
            replyMarkup: DailyDialogCommonKeyboards.FirstLevelKeyboard
        );
    }
}