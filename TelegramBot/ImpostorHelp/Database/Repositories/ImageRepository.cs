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

    public string? GetImageFileIdAsync(long chatId)
    {
        List<string>? image = _db.ImageMessages.Where(i => i.ChatId == chatId)
                                .Select(fileId => fileId.ImageFileId).ToList();
        if (image.Count == 0)
        {
            return null;
        }
        return image[_random.Next(0,image.Count)];
    }

    public async Task<bool> ImageExistInDb(string fileId)
    {
        var image = await _db.ImageMessages.FirstOrDefaultAsync(i => i.ImageFileId == fileId);
        return image is not null;
    }
}