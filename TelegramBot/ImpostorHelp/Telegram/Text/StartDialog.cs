using ImpostorHelp.Repositories;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Text;

public class StartDialog
{
    private readonly IChatRepository _chatRepository;
    private readonly JObject _sentence;
    public StartDialog(JObject sentence)
    {
        _sentence = sentence;
        _chatRepository = new ChatRepository();
    }
    
    public async Task StartingDialog (ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;
        var isActiveChat = await _chatRepository.IsActiveChat(chatId);
        Console.WriteLine($"Received a '{update.Message.Text}' message in chat {chatId}.");
        var startMessage = "Добро пожаловать";
        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: startMessage,
            cancellationToken: cancellationToken
            //replyMarkup: GetButtons()
        );

        var voiceMessage = "Запишите аудио";
         await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: voiceMessage,
            cancellationToken: cancellationToken
            //replyMarkup: GetButtons()
        );
    }
    
    
}
