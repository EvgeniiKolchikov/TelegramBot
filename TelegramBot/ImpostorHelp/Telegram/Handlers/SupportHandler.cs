using ImpostorHelp.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Handlers;

public class SupportHandler
{
    private Random _random;
    private ImageRepository _imageRepository;
    private TextMessageRepository _textMessageRepository;
    private VoiceMessageRepository _voiceMessageRepository;
    private SupportingTextFactsRepository _supportingTextFactsRepository;
    private SupportingVideoFactsRepository _supportingVideoFactsRepository;

    public SupportHandler()
    {
        _imageRepository = new ImageRepository();
        _textMessageRepository = new TextMessageRepository();
        _supportingTextFactsRepository = new SupportingTextFactsRepository();
        _supportingVideoFactsRepository = new SupportingVideoFactsRepository();
        _voiceMessageRepository = new VoiceMessageRepository();
        _random = new Random();
    }

    public async Task GetImageSupport(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var res = _imageRepository.GetImageFileIdAsync(update.CallbackQuery.From.Id);
        if (res != "")
        {
            await botClient.SendPhotoAsync(update.CallbackQuery.From.Id, res);
        }
        else
        {
            await GetVoiceSupport(botClient, update, cancellationToken);
        }
    }

    public async Task GetVoiceSupport(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var res = _voiceMessageRepository.GetChatVoiceId(update.CallbackQuery.From.Id);
        if (res != "")
        {
            await botClient.SendVoiceAsync(update.CallbackQuery.From.Id, res);
        }
        else
        {
             await GetTextSupport(botClient, update, cancellationToken);
        }
    }
    
    public async Task GetTextSupport(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var res = _textMessageRepository.GetTextFromDb(update.CallbackQuery.From.Id);
        if (res != "")
        {
            await botClient.SendTextMessageAsync(update.CallbackQuery.From.Id, res, cancellationToken: cancellationToken);
        }
        else
        {
           await GetSupportFactsText(botClient,update,cancellationToken);
        }
    }
    
    public async Task GetSupportFactsText(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var text = _supportingTextFactsRepository.GetTextFromDb();
        await botClient.SendTextMessageAsync(update.CallbackQuery.From.Id, text, cancellationToken: cancellationToken);
    }
    
}