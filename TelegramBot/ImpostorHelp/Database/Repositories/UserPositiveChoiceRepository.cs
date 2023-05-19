using ImpostorHelp.Context;
using ImpostorHelp.Database.Models;

namespace ImpostorHelp.Database.Repositories;

public class UserPositiveChoiceRepository 
{
    private ApplicationContext _db;
    private Random _random;

    public UserPositiveChoiceRepository()
    {
        _db = new ApplicationContext();
        _random = new Random();
    }

    public async Task SaveUserChoiceAsync(long chatId, int assessment)
    {
        var userPosChoice = new UserPositiveChoice
        {
            ChatId = chatId,
            DateTime = DateTime.UtcNow + TimeSpan.FromHours(3),
            Assessment = assessment
        };

        await _db.AddAsync(userPosChoice);
        await _db.SaveChangesAsync();
    }
    
}