namespace ImpostorHelp.Database.Interfaces;

public interface ITextMessageRepository
{
    Task AddTextMessageToDb(long chatId, string text);
}