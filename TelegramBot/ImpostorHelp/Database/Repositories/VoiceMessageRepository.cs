using ImpostorHelp.Context;
using ImpostorHelp.Models;

namespace ImpostorHelp.Database.Repositories;

public class VoiceMessageRepository 
{
    private readonly ApplicationContext _db;
    private Random _random;

    public VoiceMessageRepository()
    {
        _db = new ApplicationContext();
        _random = new Random();
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
    public string? GetChatVoiceId(long chatId)
    {
        var voice = _db.VoiceMessages.Where(v => v.ChatId == chatId).Select(v => v.VoiceMessageFileId).ToList();
        if (voice.Count == 0)
        {
            return null;
        }
        return voice[_random.Next(0,voice.Count)];
    }
    
    

}