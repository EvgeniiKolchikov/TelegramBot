using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp;

public class BotController
{
    public async Task DialogControl(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message) return;
        if (message.Text is not { } messageText) return;
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

    public async Task StartDialog(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var message = update.Message;
        var messageText = message.Text;
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