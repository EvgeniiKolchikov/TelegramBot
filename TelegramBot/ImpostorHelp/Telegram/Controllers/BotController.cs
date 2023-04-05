using ImpostorHelp.Telegram.Controllers.Text;
using ImpostorHelp.Telegram.Controllers.Voice;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;

namespace ImpostorHelp.Telegram.Controllers;

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
        switch (update.Type)
        {
            case UpdateType.Message:
                var text = update.Message.Text;
                switch (text)
                {
                    case "/start":
                        await _startDialog.StartingDialog(botClient, update, cancellationToken);
                        break;
                    
                    // default:
                    //     await _startDialog.StartingDialog(botClient, update, cancellationToken);
                    //     break;
                }
                
               break;
            
            case UpdateType.CallbackQuery : 
                await _startDialog.StartingDialog(botClient, update, cancellationToken);
                break;
        }
    }
}
