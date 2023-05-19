using ImpostorHelp.Context;
using ImpostorHelp.Models;

namespace ImpostorHelp.Database.Repositories;

public class TextMessageRepository
{
    private readonly ApplicationContext _db;
    private Random _random;
    public TextMessageRepository()
    {
        _db = new ApplicationContext();
        _random = new Random();
    }

    public async Task AddTextMessageToDb(long chatId, string text)
    {
        var textMessage = new TextMessage
        {
            ChatId = chatId,
            Message = text,
            DateTime = DateTime.UtcNow + TimeSpan.FromHours(3)
        };
        await _db.TextMessages.AddAsync(textMessage);
        await _db.SaveChangesAsync();
    }

    public string GetTextFromDb(long chatId)
    {
        var text = _db.TextMessages.Where(t => t.ChatId == chatId);
        var messages = text.Select(t => t.Message).ToList();
        return messages[_random.Next(messages.Count)];
    }
}