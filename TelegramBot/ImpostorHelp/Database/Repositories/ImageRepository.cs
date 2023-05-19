using ImpostorHelp.Context;
using ImpostorHelp.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ImpostorHelp.Database.Repositories;

public class ImageRepository
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

    public string GetImageFileIdAsync(long chatId)
    {
        var image = _db.ImageMessages.Where(i => i.ChatId == chatId).ToList();
        var id = image.Select(fileId => fileId.ImageFileId).ToList();
        return id[_random.Next(id.Count - 1)];
    }

    public async Task<bool> ImageExistInDb(string fileId)
    {
        var image = await _db.ImageMessages.FirstOrDefaultAsync(i => i.ImageFileId == fileId);
        return image is not null;
    }
}