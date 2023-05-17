using ImpostorHelp.Models;

namespace ImpostorHelp;

public interface IVoiceMessageRepository
{
    Task AddVoiceMessageToDb(long chatId,string fileId);
    public int GetChatVoiceMessagesCount(long chatId);
}