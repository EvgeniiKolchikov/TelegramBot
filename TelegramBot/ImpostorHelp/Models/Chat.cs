using System.Reflection;

namespace ImpostorHelp.Models;

public class Chat 
{
    public int Id { get; set; }
    public string ChatId { get; set; } = "";
    public bool IsActive { get; set; }
    public DateTime NotificationTime { get; set; }
    public DateTime NextDayNotification { get; set; }
    public DateTime NextWeekNotification { get; set; }
    public DateTime NextMonthNotification { get; set; }
}