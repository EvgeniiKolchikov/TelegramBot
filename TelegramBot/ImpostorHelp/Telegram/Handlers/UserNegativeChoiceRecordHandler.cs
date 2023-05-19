using ImpostorHelp.Database.Repositories;

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

    public bool SecondMoreThanFirst(long chatId)
    {
        return _choiceRepository.SecondMoreThanFirst(chatId);
    }
}