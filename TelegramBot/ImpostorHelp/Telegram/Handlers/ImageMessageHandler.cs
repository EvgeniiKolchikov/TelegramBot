using ImpostorHelp.Database.Interfaces;
using ImpostorHelp.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Handlers;

public class ImageMessageHandler
{
    private IImageRepository _imageRepository;
    private bool _imageSavedInDb;

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
                _imageSavedInDb = await _imageRepository.ImageExistInDb(fileId);
            }

            await botClient.DeleteMessageAsync(chatId, update.Message.MessageId, cancellationToken);
            if (_imageSavedInDb)
            {
                await botClient.SendTextMessageAsync(chatId, "Сохранено", cancellationToken: cancellationToken);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId, "Ошибка сохранения, попробуйте еще раз", cancellationToken: cancellationToken);
            }
        }
    }
}