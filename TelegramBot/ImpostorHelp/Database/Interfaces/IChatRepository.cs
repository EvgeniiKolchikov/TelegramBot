namespace ImpostorHelp;

public interface IChatRepository
{
    Task<bool> IsActiveChat(long chatId);
    Task AddChatToDb(long chatId);
}