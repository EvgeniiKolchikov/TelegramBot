namespace ImpostorHelp;

public interface IChatRepository
{
    Task<bool> IsActiveChat(string chatId);
}