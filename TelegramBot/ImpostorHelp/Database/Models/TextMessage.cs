namespace ImpostorHelp.Models;

public class TextMessage
{
    public int Id { get; set; }
    public long ChatId { get; set; }
    public string Message{ get; set; } = "";
}