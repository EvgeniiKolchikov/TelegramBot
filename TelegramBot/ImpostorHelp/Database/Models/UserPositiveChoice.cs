namespace ImpostorHelp.Database.Models;

public class UserPositiveChoice
{
    public int Id { get; set; }
    public long ChatId { get; set; }
    public DateTime DateTime { get; set; }
    public int Assessment { get; set; }
}