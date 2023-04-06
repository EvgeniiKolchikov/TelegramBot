using ImpostorHelp.Repositories;
using ImpostorHelp.Telegram.StaticClasses;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Controllers.Voice;

public class VoiceMessagesHandler
{
    private readonly IVoiceMessageRepository _voiceMessageRepository;
    public VoiceMessagesHandler()
    {
        _voiceMessageRepository = new VoiceMessageRepository();
    }

    public async Task AddVoiceToDb(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;
        var fileId = update.Message.Voice.FileId;
        await _voiceMessageRepository.AddVoiceMessageFileIdToDb(chatId, fileId);
        var voiceMessagesCount = _voiceMessageRepository.GetChatVoiceMessagesCount(chatId);
        var text = $"Отлично, у вас всего {voiceMessagesCount} записей. Лучше всего иметь 5";
        await botClient.SendTextMessageAsync(chatId, text, 
            cancellationToken: cancellationToken,replyMarkup:StartDialogKeyboards.AfterAudioRecordKeyboard);
    }

    
}