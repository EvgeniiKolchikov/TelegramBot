namespace ImpostorHelp.Database.Models;

public class ImageMessage
{
    public int Id { get; set; }
    public long ChatId { get; set; }
    public string ImageFileId { get; set; } = "";
    public DateTime MessageRecordedTime { get; set; }
    public string Text { get; set; } = "";
}