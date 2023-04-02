using ImpostorHelp.Context;
using ImpostorHelp.Models;
using Microsoft.EntityFrameworkCore;

namespace ImpostorHelp.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly ApplicationContext _db;
    public ChatRepository()
    {
        _db = new ApplicationContext();
    }

    public async Task<bool> IsActiveChat(long chatId)
    {
        var isActive = await _db.Chats.AnyAsync(c => c.ChatId == chatId && c.IsActive == true);
        if (!isActive)
        {
            await AddChatToDb(chatId);
        }
        return isActive;
    }

    public async Task AddChatToDb(long chatId)
    {
        var chat = new Chat
        {
            ChatId = chatId,
            IsActive = true
        };
        await _db.Chats.AddAsync(chat);
        await _db.SaveChangesAsync();
    }
}