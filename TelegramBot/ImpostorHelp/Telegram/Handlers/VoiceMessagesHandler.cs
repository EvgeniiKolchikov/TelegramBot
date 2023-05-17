using ImpostorHelp.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Handlers;

public class VoiceMessagesHandler
{
    private readonly IVoiceMessageRepository _voiceMessageRepository;
    public VoiceMessagesHandler()
    {
        _voiceMessageRepository = new VoiceMessageRepository();
    }

    public async Task AddVoiceToDbAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message != null)
        {
            var chatId = update.Message.Chat.Id;
            if (update.Message.Voice != null)
            {
                var fileId = update.Message.Voice.FileId;
                await _voiceMessageRepository.AddVoiceMessageToDb(chatId, fileId);
            }

            await botClient.DeleteMessageAsync(update.Message.Chat.Id,update.Message.MessageId,cancellationToken);
            
            var text = "Сохранено";
            await botClient.SendTextMessageAsync(chatId, text, 
                cancellationToken: cancellationToken);
           
        }
    }
    
}