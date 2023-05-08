using ImpostorHelp.Database.Repositories;
using ImpostorHelp.Repositories;
using ImpostorHelp.Telegram.Dialogs;
using ImpostorHelp.Telegram.Handlers;
using ImpostorHelp.Telegram.Voice;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;

namespace ImpostorHelp.Telegram;

public class BotController
{
    private readonly IChatRepository _chatRepository;
    private readonly IVoiceMessageRepository _voiceMessageRepository;
    private readonly StartDialog _startDialog;
    private readonly DailyPositiveDialog _dailyPositiveDialog;
    private readonly DailyNegativeDialog _dailyNegativeDialog;
    private readonly StandardResponse _standardResponse;
    private readonly VoiceMessagesHandler _voiceMessagesHandler;
    private readonly TextMessageHandler _textMessageHandler;
    private readonly MessagesToStartConversation _messagesToStartConversation;
    public BotController()
    {
        _chatRepository = new ChatRepository();
        _voiceMessageRepository = new VoiceMessageRepository();
        _startDialog = new StartDialog(_chatRepository,_voiceMessageRepository);
        _dailyPositiveDialog = new DailyPositiveDialog();
        _standardResponse = new StandardResponse();
        _voiceMessagesHandler = new VoiceMessagesHandler();
        _textMessageHandler = new TextMessageHandler();
        _messagesToStartConversation = new MessagesToStartConversation();
        _dailyNegativeDialog = new DailyNegativeDialog();
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
                        
                        case "/daily" :
                            await _messagesToStartConversation.DailyTextDialog(botClient, update, cancellationToken);
                            break;
                        
                        default:
                            await _textMessageHandler.AddTextMessage(botClient, update, cancellationToken);
                            break;
                    }
                }
                if (update.Message != null && update.Message.Voice != null)
                {
                    await _voiceMessagesHandler.AddVoiceToDb(botClient,update,cancellationToken);
                }
               break;
            
            case UpdateType.CallbackQuery :
                
                if (update.CallbackQuery != null && update.CallbackQuery.Data != null &&
                    update.CallbackQuery.Data.Contains("StartDialog"))
                {
                    await _startDialog.StartingCallBackQueryDialog(botClient, update, cancellationToken);
                }
                if (update.CallbackQuery != null && update.CallbackQuery.Data != null && 
                    update.CallbackQuery.Data.Contains("DailyPositiveDialog"))
                {
                    await _dailyPositiveDialog.DailyPositiveCallBackQueryDialog(botClient, update, cancellationToken);
                }
                if (update.CallbackQuery != null && update.CallbackQuery.Data != null && 
                    update.CallbackQuery.Data.Contains("DailyNegativeDialog"))
                {
                    await _dailyNegativeDialog.DailyNegativeCallBackQueryDialog(botClient, update, cancellationToken);
                }
                else
                {
                    await _standardResponse.StandardCallBackQueryResponse(botClient, update, cancellationToken);
                }
                break;
        }
    }
}
