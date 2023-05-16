using ImpostorHelp.Context;
using ImpostorHelp.Database.Models;
using ImpostorHelp.Models;
using Microsoft.EntityFrameworkCore;

namespace ImpostorHelp.Database.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly ApplicationContext _db;
    public ChatRepository()
    {
        _db = new ApplicationContext();
    }

    public async Task AddChatToDb(long chatId)
    {
        var chatFromDb = await _db.Chats.FirstOrDefaultAsync(c => c.ChatId == chatId);
        if (chatFromDb is not null) return;
        var chat = new Chat
        {
            ChatId = chatId,
            NotificationTime = TimeOnly.FromDateTime(DateTime.UtcNow + TimeSpan.FromHours(3))
        };
        await _db.Chats.AddAsync(chat);
        await _db.SaveChangesAsync();
    }

    public async Task AddNotificationTimeAsync(long chatId, TimeOnly time)
    {
        var chat = _db.Chats.FirstOrDefault(c => c.ChatId == chatId);
        if (chat != null)
        {
            chat.NotificationTime = time;
            _db.Chats.Update(chat);
        }

        await _db.SaveChangesAsync();
    }
}