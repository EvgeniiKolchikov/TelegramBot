using ImpostorHelp.Models;

namespace ImpostorHelp;

public interface IVoiceMessageRepository
{
    Task AddVoiceMessageFileIdToDb(long chatId,string fileId);
    IEnumerable<VoiceMessage> GetAllChatVoiceMessages(long chatId);
}