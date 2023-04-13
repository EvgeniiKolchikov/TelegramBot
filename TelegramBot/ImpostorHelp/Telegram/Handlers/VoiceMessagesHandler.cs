using ImpostorHelp.Repositories;
using ImpostorHelp.Telegram.StaticClasses;
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

    public async Task AddVoiceToDb(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message != null)
        {
            var chatId = update.Message.Chat.Id;
            if (update.Message.Voice != null)
            {
                var fileId = update.Message.Voice.FileId;
                await _voiceMessageRepository.AddVoiceMessageIdToDb(chatId, fileId);
            }

            var voiceMessagesCount = _voiceMessageRepository.GetChatVoiceMessagesCount(chatId);
            var text = $"Отлично, у вас всего {voiceMessagesCount} записей";
            await botClient.SendTextMessageAsync(chatId, text, 
                cancellationToken: cancellationToken,replyMarkup:RecordsKeyboard.AfterRecordKeyboard);
        }
    }

    
}