using ImpostorHelp.Context;
using Microsoft.EntityFrameworkCore;

namespace ImpostorHelp.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly ApplicationContext _db;
    public ChatRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<bool> IsActiveChat(string chatId)
    {
        var isActive = await _db.Chats.AnyAsync(c => c.ChatId == chatId && c.IsActive == true);
        return isActive;
    }
}