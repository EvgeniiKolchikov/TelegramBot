namespace ImpostorHelp.Models;

public class VoiceMessage
{
    public int Id { get; set; }
    public long ChatId { get; set; }
    public string VoiceMessageFileId { get; set; } = "";
    public DateTime MessageRecordedTime { get; set; }
}