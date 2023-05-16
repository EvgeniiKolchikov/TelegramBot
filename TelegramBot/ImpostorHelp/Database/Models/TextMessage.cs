namespace ImpostorHelp.Models;

public class TextMessage
{
    public int Id { get; set; }
    public long ChatId { get; set; }
    public DateTime DateTime { get; set; }
    public string Message{ get; set; } = "";
    public bool IsShowedLastTwoWeeks { get; set; }
    
}