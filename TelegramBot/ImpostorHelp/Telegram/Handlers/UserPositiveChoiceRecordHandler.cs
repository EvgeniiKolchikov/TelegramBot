using ImpostorHelp.Database.Repositories;

namespace ImpostorHelp.Telegram.Handlers;

public class UserPositiveChoiceRecordHandler
{
    private UserPositiveChoiceRepository _positiveChoiceRepository;

    public UserPositiveChoiceRecordHandler()
    {
        _positiveChoiceRepository = new UserPositiveChoiceRepository();
    }
    
    public async Task SaveChoiceAsync(long chatId, string callBackData)
    {
        var numberString = callBackData.Substring(callBackData.Length - 2, 2);
        var isNumber = int.TryParse(numberString, out var assessment);

        await _positiveChoiceRepository.SaveUserChoiceAsync(chatId, assessment);
    }
}