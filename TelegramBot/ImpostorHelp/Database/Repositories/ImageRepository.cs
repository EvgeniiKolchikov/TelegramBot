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
        var text = await _db.TextMessages.Where(t => t.ChatId == chatId)
            .OrderByDescending(t => t.DateTime)
            .FirstAsync();
        var image = new ImageMessage
        {
            ChatId = chatId,
            ImageFileId = fileId,
            MessageRecordedTime = DateTime.UtcNow + TimeSpan.FromHours(3),
            Text = text.Message
        };

        await _db.ImageMessages.AddAsync(image);
        await _db.SaveChangesAsync();
    }

    public string[]? GetImageFileIdAsync(long chatId)
    {
        var image = _db.ImageMessages.Where(i => i.ChatId == chatId).ToList();
        
        if (image.Count == 0)
        {
            return null;
        }

        var rndImage = image[_random.Next(0,image.Count)];
        var res = new string[2];
        res[0] = rndImage.ImageFileId;
        res[1] = rndImage.Text;
        return res;
    }

    public async Task<bool> ImageExistInDb(string fileId)
    {
        var image = await _db.ImageMessages.FirstOrDefaultAsync(i => i.ImageFileId == fileId);
        return image is not null;
    }
}