namespace ImpostorHelp.Models;

public class Notification
{
    public int Id { get; set; }
    public string ChatId { get; set; } = "";
    public DateTime NotificationTime { get; set; }
    public DateTime NextDayNotification { get; set; }
    public DateTime NextWeekNotification { get; set; }
    public DateTime NextMonthNotification { get; set; }
}