using ImpostorHelp.Context;
using ImpostorHelp.Database.Models;

namespace ImpostorHelp.Database.Repositories;

public class UserNegativeChoiceRepository
{
    private ApplicationContext _db;
    private DateTime _todayDate;

    public UserNegativeChoiceRepository()
    {
        _db = new ApplicationContext();
        _todayDate = DateTime.UtcNow.Date;
    }
    
    public async Task SaveFirstUserChoiceAsync(long chatId, int assessment)
    {
        var userNegChoice = new UserNegativeChoice()
        {
            ChatId = chatId,
            RecordDate = DateTime.UtcNow + TimeSpan.FromHours(3),
            FirstAssessment = assessment
        };

        await _db.AddAsync(userNegChoice);
        await _db.SaveChangesAsync();
    }

    public async Task SaveSecondUserChoiceAsync(long chatId, int assessment)
    {
        
        var userNegChoice = _db.UserNegativeChoices
            .Where(unc => unc.ChatId == chatId && unc.RecordDate > _todayDate.AddDays(-1) 
                                               && unc.RecordDate < _todayDate.AddDays(1)).ToList();
        
        userNegChoice[userNegChoice.Count - 1].SecondAssessment = assessment;
        _db.UserNegativeChoices.Update(userNegChoice[userNegChoice.Count - 1]);
        await _db.SaveChangesAsync();
    }

    public bool SecondMoreThanFirst(long chatId)
    {
        var compared = _db.UserNegativeChoices
        .Where(unc => unc.ChatId == chatId && unc.RecordDate > _todayDate.AddDays(-1) 
                                           && unc.RecordDate < _todayDate.AddDays(1)
                                           && unc.SecondAssessment > 0).ToList();
        return compared[^1].SecondAssessment >= compared[^1].FirstAssessment;
    }

    public int GetFirstChoiceFromDb(long chatId)
    {
        var list = _db.UserNegativeChoices
            .Where(unc => unc.ChatId == chatId && unc.FirstAssessment > 0 
                                               && unc.SecondAssessment > 0
                                               && unc.RecordDate > _todayDate.AddDays(-1)
                                               && unc.RecordDate < _todayDate.AddDays(1)).ToList();
        return list[^1].FirstAssessment;
    }
    
    public int GetSecondChoiceFromDb(long chatId)
    {
        var list = _db.UserNegativeChoices
            .Where(unc => unc.ChatId == chatId && unc.FirstAssessment > 0 
                                               && unc.SecondAssessment > 0
                                               && unc.RecordDate > _todayDate.AddDays(-1)
                                               && unc.RecordDate < _todayDate.AddDays(1)).ToList();
        return list[^1].SecondAssessment;
    }
}