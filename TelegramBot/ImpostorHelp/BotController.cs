using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp;

public class BotController
{
    public async Task DialogControl(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var message = update.Message;
        var messageText = message.Text;
        if (messageText != null)
        {
            switch (messageText)
            {
                case "/start":
                    await StartDialog(botClient, update, cancellationToken);
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }
        
    }

    public async Task StartDialog(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var fileId = "AwACAgIAAxkBAANmZCXWgD-05V22HwrECYKrZSzVe18AAjEqAAL8FjBJplufDIO5F7gvBA";
        var message = update.Message;
        var messageText = message.Text;
        var startMessage = ConfigurationHelper.GetStringFromConfigurationFile("StartMessage");
        var chatId = message.Chat.Id;
        Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

        var sentMessage = await botClient.SendDocumentAsync(
                chatId: chatId,
                document: fileId
        );
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