namespace ImpostorHelp.Database.Models;

public class Chat 
{
    public int Id { get; set; }
    public long ChatId { get; set; }
    public TimeOnly NotificationTime { get; set; }

}