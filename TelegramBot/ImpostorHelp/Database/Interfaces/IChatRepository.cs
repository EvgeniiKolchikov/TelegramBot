namespace ImpostorHelp;

public interface IChatRepository
{
    Task AddChatToDb(long chatId);
    Task AddNotificationTimeAsync(long chatId, TimeOnly time);
}