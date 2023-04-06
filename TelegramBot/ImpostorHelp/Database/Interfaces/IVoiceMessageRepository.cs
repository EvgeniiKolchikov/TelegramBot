using ImpostorHelp.Models;

namespace ImpostorHelp;

public interface IVoiceMessageRepository
{
    Task AddVoiceMessageFileIdToDb(long chatId,string fileId);
    public int GetChatVoiceMessagesCount(long chatId);
}