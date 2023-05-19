namespace ImpostorHelp.Database.Models;

public class UserNegativeChoice
{
    public int Id { get; set; }
    public long ChatId { get; set; }
    public DateTime RecordDate { get; set; }
    public int FirstAssessment { get; set; }
    public int SecondAssessment { get; set; }
}