using ImpostorHelp.Database.Interfaces;
using ImpostorHelp.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Handlers;

public class ImageMessageHandler
{
    private IImageRepository _imageRepository;

    public ImageMessageHandler()
    {
        _imageRepository = new ImageRepository();
    }

    public async Task AddImageToDbAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (update.Message != null)
        {
            var chatId = update.Message.Chat.Id;

            if (update.Message.Photo != null)
            {
                var fileId = update.Message.Photo.Last().FileId;
                await _imageRepository.AddImageToDbAsync(chatId, fileId);
            }

            await botClient.DeleteMessageAsync(chatId, update.Message.MessageId, cancellationToken);

            var id = await _imageRepository.GetImageFileIdAsync(chatId);
            await botClient.SendPhotoAsync(chatId, id);
        }
    }
}