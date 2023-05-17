namespace ImpostorHelp.Database.Interfaces;

public interface IImageRepository
{
    Task AddImageToDbAsync(long chatId, string fileId);
    Task<string> GetImageFileIdAsync(long chatId);
}