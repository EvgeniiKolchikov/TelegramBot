using ImpostorHelp.Context;
using ImpostorHelp.Database.Interfaces;
using ImpostorHelp.Models;

namespace ImpostorHelp.Database.Repositories;

public class TextMessageRepository : ITextMessageRepository
{
    private readonly ApplicationContext _db;
    public TextMessageRepository()
    {
        _db = new ApplicationContext();
    }

    public async Task AddTextMessageToDb(long chatId, string text)
    {
        var textMessage = new TextMessage
        {
            ChatId = chatId,
            Message = text
        };
        await _db.TextMessages.AddAsync(textMessage);
        await _db.SaveChangesAsync();
    }
}