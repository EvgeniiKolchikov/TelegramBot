using ImpostorHelp.Context;
using ImpostorHelp.Models;

namespace ImpostorHelp.Repositories;

public class VoiceMessageRepository : IVoiceMessageRepository
{
    private readonly ApplicationContext _db;

    public VoiceMessageRepository()
    {
        _db = new ApplicationContext();
    }

    public async Task AddVoiceMessageToDb(long chatId, string fileId)
    {
        var voiceMessage = new VoiceMessage
        {
            ChatId = chatId,
            VoiceMessageFileId = fileId,
            MessageRecordedTime = DateTime.UtcNow
        };
        await _db.VoiceMessages.AddAsync(voiceMessage);
        await _db.SaveChangesAsync();
    }
    public int GetChatVoiceMessagesCount(long chatId)
    {
       return _db.VoiceMessages.Where(m => m.ChatId == chatId).ToList().Count;
    }
    
    

}