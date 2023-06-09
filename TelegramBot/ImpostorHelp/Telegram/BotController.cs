using System.Text.RegularExpressions;
using ImpostorHelp.Database.Repositories;
using ImpostorHelp.Telegram.Dialogs;
using ImpostorHelp.Telegram.Handlers;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;

namespace ImpostorHelp.Telegram;

public class BotController
{
    private readonly ChatRepository _chatRepository;
    private readonly VoiceMessageRepository _voiceMessageRepository;
    private readonly StartDialog _startDialog;
    private readonly DailyPositiveDialog _dailyPositiveDialog;
    private readonly DailyNegativeDialog _dailyNegativeDialog;
    private readonly VoiceMessagesHandler _voiceMessagesHandler;
    private readonly TextMessageHandler _textMessageHandler;
    private readonly ImageMessageHandler _imageMessageHandler;
    private readonly MessagesToStartConversation _messagesToStartConversation;
    private readonly NotificationTimeSetter _notificationTimeSetter;
    private readonly HelpMessageSender _helpMessageSender;
    public BotController()
    {
        _chatRepository = new ChatRepository();
        _voiceMessageRepository = new VoiceMessageRepository();
        _startDialog = new StartDialog();
        _dailyPositiveDialog = new DailyPositiveDialog();
        _voiceMessagesHandler = new VoiceMessagesHandler();
        _textMessageHandler = new TextMessageHandler();
        _messagesToStartConversation = new MessagesToStartConversation();
        _dailyNegativeDialog = new DailyNegativeDialog();
        _notificationTimeSetter = new NotificationTimeSetter();
        _imageMessageHandler = new ImageMessageHandler();
        _helpMessageSender = new HelpMessageSender();
    }

    public async Task Run(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        switch (update.Type)
        {
            case UpdateType.Message:
                if (update.Message != null && update.Message.Text is not null)
                {
                    var text = update.Message.Text;
                    if (text == "/start")
                    {
                        await _chatRepository.AddChatToDb(update.Message.Chat.Id);
                        await _startDialog.StartingTextDialog(botClient, update, cancellationToken);
                    }
                    else if (text == "/daily")
                    {
                        await _messagesToStartConversation.DailyTextDialog(botClient, update, cancellationToken);
                    }
                    else if (text == "/notification")
                    {
                        await _notificationTimeSetter.MessageBeforeTimeChange(botClient, update, cancellationToken);
                    }
                    else if (text == "/help")
                    {
                        await _helpMessageSender.SendHelpMessage(botClient, update, cancellationToken);
                    }
                    else if (text.StartsWith("Время."))
                    {
                        await _notificationTimeSetter.SetNotificationTimeFromText(botClient, update, cancellationToken);
                    }
                    else if (text.StartsWith("Воспоминание"))
                    {
                        await _textMessageHandler.AddTextMessage(botClient, update, cancellationToken);
                    }
                    
                }
                
                if (update.Message != null && update.Message.Voice != null)
                {
                    await _voiceMessagesHandler.AddVoiceToDbAsync(botClient,update,cancellationToken);
                }

                if (update.Message != null && update.Message.Photo != null)
                {
                    await _imageMessageHandler.AddImageToDbAsync(botClient, update, cancellationToken);
                }
               break;
            
            case UpdateType.CallbackQuery :
                
                if (update.CallbackQuery != null && update.CallbackQuery.Data != null &&
                    update.CallbackQuery.Data.Contains("StartDialog"))
                {
                    if (update.CallbackQuery.Data.Contains("5Level.Time"))
                    {
                        await _notificationTimeSetter.SetNotificationTimeFromCallBack(botClient, update, cancellationToken);
                    }
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
                break;
            
        }
    }

    
}
