using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp;

public class BotController
{
    public async Task SendMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message) return;
        if (message.Text is not { } messageText) return;

        var chatId = message.Chat.Id;
        Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
        var sentMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "You said:\n" + messageText,
            cancellationToken: cancellationToken,
            replyMarkup: GetButtons()
        );
    }

    public async Task StartDialog(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message) return;
        if (message.Text is not { } messageText) return;
        if (messageText == "/start")
        {
            var startMessage = ConfigurationHelper.GetStringFromConfigurationFile("StartMessage");
            var chatId = message.Chat.Id;
            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
            
            var sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: startMessage,
                cancellationToken: cancellationToken,
                replyMarkup: GetButtons()
            );
        }
    }
    private static IReplyMarkup GetButtons()
    {

        var buttonList = new List<KeyboardButton> { new KeyboardButton("fsdf"), new KeyboardButton("jksd") };
        return new ReplyKeyboardMarkup(new List<KeyboardButton>
        {
            new KeyboardButton("fsdf"),
            new KeyboardButton("jksd")
        })
        {
            ResizeKeyboard = true
        };
    }
}