using ImpostorHelp.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Handlers;

public class UserNegativeChoiceRecordHandler
{
    private UserNegativeChoiceRepository _choiceRepository;

    public UserNegativeChoiceRecordHandler()
    {
        _choiceRepository = new UserNegativeChoiceRepository();
    }
    
    public async Task SaveFirstChoiceAsync(long chatId, string callBackData)
    {
        var numberString = callBackData.Substring(callBackData.Length - 2, 2);
        var isNumber = int.TryParse(numberString, out var assessment);

        await _choiceRepository.SaveFirstUserChoiceAsync(chatId, assessment);
    }
    
    public async Task SaveSecondChoiceAsync(long chatId, string callBackData)
    {
        var numberString = callBackData.Substring(callBackData.Length - 2, 2);
        int.TryParse(numberString, out var assessment);

        await _choiceRepository.SaveSecondUserChoiceAsync(chatId, assessment);
    }

    public int? GetFirstChoice(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var chatId = update.CallbackQuery.From.Id;
        try
        {
            return _choiceRepository.GetFirstChoiceFromDb(chatId);
        }
        catch (Exception)
        {
            botClient.SendTextMessageAsync(chatId, "Ошибка, что-то пошло не так :(" +
                                                   "Обратитесь в чат помощи",
                cancellationToken: cancellationToken);
            return null;
        }
    }

    public int? GetSecondChoice(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var chatId = update.CallbackQuery.From.Id;

        try
        {
            return _choiceRepository.GetSecondChoiceFromDb(chatId);
        }
        catch (Exception e)
        {
            botClient.SendTextMessageAsync(chatId, "Ошибка, что-то пошло не так :(" +
                                                   "Обратитесь в чат помощи",
                cancellationToken: cancellationToken);
            return null;
        }

    }
    public bool SecondMoreThanFirst(long chatId)
    {
        return _choiceRepository.SecondMoreThanFirst(chatId);
    }
}