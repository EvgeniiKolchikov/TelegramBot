using ImpostorHelp.Repositories;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Controllers.Voice;

public class VoiceMessagesController
{
    private readonly IVoiceMessageRepository _voiceMessageRepository;
    public VoiceMessagesController()
    {
        _voiceMessageRepository = new VoiceMessageRepository();
    }

    public async Task AddVoiceToDb(Update update)
    {
        var chatId = update.Message.Chat.Id;
        var fileId = update.Message.Voice.FileId;
        await _voiceMessageRepository.AddVoiceMessageFileIdToDb(chatId, fileId);
    }

    // public async Task SendAllVoiceMessages(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    // {
    //     
    //     var chatId = update.Message.Chat.Id;
    //     await botClient.SendDocumentAsync(
    //         chatId: chatId,
    //         document: fil
    //     );
    // }
}