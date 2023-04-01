namespace ImpostorHelp.Models;

public class VoiceMessage
{
    public int Id { get; set; }
    public string ChatId { get; set; } = "";
    public string VoiceMessageFileId { get; set; } = "";
}