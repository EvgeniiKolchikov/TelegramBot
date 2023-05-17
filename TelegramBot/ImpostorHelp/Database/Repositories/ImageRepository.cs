using ImpostorHelp.Context;
using ImpostorHelp.Database.Interfaces;
using ImpostorHelp.Database.Models;

namespace ImpostorHelp.Database.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly ApplicationContext _db;
    private readonly Random _random;

    public ImageRepository()
    {
        _db = new ApplicationContext();
        _random = new Random();
    }

    public async Task AddImageToDbAsync(long chatId, string fileId)
    {
        var image = new ImageMessage
        {
            ChatId = chatId,
            ImageFileId = fileId,
            MessageRecordedTime = DateTime.UtcNow + TimeSpan.FromHours(3)
        };

        await _db.ImageMessages.AddAsync(image);
        await _db.SaveChangesAsync();
    }

    public async Task<string> GetImageFileIdAsync(long chatId)
    {
        var image = _db.ImageMessages.Where(i => i.ChatId == chatId).ToList();
        var id = image.Select(fileId => fileId.ImageFileId).ToList();
        return id[0];
    }
}