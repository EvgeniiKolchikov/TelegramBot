using ImpostorHelp.Models;

namespace ImpostorHelp;

public interface IVoiceMessageRepository
{
    Task AddVoiceMessageIdToDb(long chatId,string fileId);
    public int GetChatVoiceMessagesCount(long chatId);
}