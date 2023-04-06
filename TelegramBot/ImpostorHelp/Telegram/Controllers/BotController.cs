using ImpostorHelp.Repositories;
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
    private readonly IChatRepository _chatRepository;
    private readonly IVoiceMessageRepository _voiceMessageRepository;
    private readonly StartDialog _startDialog;
    private readonly VoiceMessagesHandler _voiceMessagesHandler;
    static readonly string JsonPath = Directory.GetCurrentDirectory() + "/dialog.json";
    private readonly JObject _sentence = JObject.Parse(File.ReadAllText(JsonPath));

    public BotController()
    {
        _chatRepository = new ChatRepository();
        _voiceMessageRepository = new VoiceMessageRepository();
        _startDialog = new StartDialog(_chatRepository,_voiceMessageRepository);
        _voiceMessagesHandler = new VoiceMessagesHandler();
    }

    public async Task Run(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        switch (update.Type)
        {
            case UpdateType.Message:
                if (update.Message != null && update.Message.Text is not null)
                {
                    var text = update.Message.Text;
                    switch (text)
                    {
                        case "/start":
                            await _startDialog.StartingTextDialog(botClient, update, cancellationToken);
                            break;
                        
                        // default:
                        //     await _startDialog.StartingTextDialog(botClient, update, cancellationToken);
                        //     break;
                    }
                }

                if (update.Message.Voice is not null)
                {
                    await _voiceMessagesHandler.AddVoiceToDb(botClient,update,cancellationToken);
                }
               break;
            
            case UpdateType.CallbackQuery :
                if (update.CallbackQuery.Data.Contains("StartDialog"))
                {
                    await _startDialog.StartingCallBackQueryDialog(botClient, update, cancellationToken);
                }
                break;
            
        }
    }
}
