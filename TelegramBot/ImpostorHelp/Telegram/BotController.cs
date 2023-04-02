using ImpostorHelp.Telegram.Text;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace ImpostorHelp.Telegram;

public class BotController
{
    private readonly StartDialog _startDialog;
    private readonly VoiceMessagesController _voiceMessagesController;
    static readonly string JsonPath = Directory.GetCurrentDirectory() + "/dialog.json";
    private readonly JObject _sentence = JObject.Parse(File.ReadAllText(JsonPath));
    public BotController()
    {
        _startDialog = new StartDialog(_sentence);
        _voiceMessagesController = new VoiceMessagesController();
    }
    
    public async Task Run(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message) return;
        if (message.Text is { } messageText)
        {
            switch (messageText)
            {
                case "/start" : 
                await _startDialog.StartingDialog(botClient, update, cancellationToken);
                    break;
            }
        }

        if (message.Voice is { } messageVoice)
        {
            await _voiceMessagesController.AddVoiceToDb(update);
        }
    }
}