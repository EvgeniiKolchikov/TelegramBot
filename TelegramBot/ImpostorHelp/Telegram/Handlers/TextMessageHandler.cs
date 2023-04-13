using ImpostorHelp.Database.Interfaces;
using ImpostorHelp.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Voice;

public class TextMessageHandler
{
    private readonly ITextMessageRepository _textMessageRepository;
    public TextMessageHandler()
    {
        _textMessageRepository = new TextMessageRepository();
    }

    public async Task AddTextMessage(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (update.Message != null)
        {
            var chatId = update.Message.Chat.Id;
            if (update.Message.Text != null)
            {
                await _textMessageRepository.AddTextMessageToDb(chatId, update.Message.Text);
            }
            
            var text = $"Отлично!";
            await botClient.SendTextMessageAsync(chatId, text, 
                cancellationToken: cancellationToken);
        }
    }
}