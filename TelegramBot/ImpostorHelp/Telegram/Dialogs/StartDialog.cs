using ImpostorHelp.Telegram.StaticClasses;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Dialogs;

public class StartDialog
{
    private readonly IChatRepository _chatRepository;
    private readonly IVoiceMessageRepository _voiceMessageRepository;
    private readonly JObject _sentence;

    public StartDialog(IChatRepository chatRepository, IVoiceMessageRepository voiceMessageRepository)
    {
        _chatRepository = chatRepository;
        _voiceMessageRepository = voiceMessageRepository;
    }
    
    public async Task StartingTextDialog (ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;
        Console.WriteLine($"Received a '{update.Message.Text}' message in chat {chatId}.");
        var startMessage = "Добро пожаловать. Стартовое сообщение с описанием и вариантами ответа";
        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: startMessage,
            cancellationToken: cancellationToken,
            replyMarkup: StartDialogKeyboards.FirstLevelKeyboard
        );
    }

    public async Task StartingCallBackQueryDialog(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var chatId = update.CallbackQuery.From.Id;
            switch (update.CallbackQuery.Data)
            {
                case "StartDialog.1Level.Yes":
                    var level1YesMessage = "Положительный ответ 1 уровень (Приступаем к записи аудиосообщений)";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level1YesMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: StartDialogKeyboards.SecondLevelKeyboard
                    );
                    break;
                case "StartDialog.1Level.No":
                    var level1NoMessage = "отрицательный ответ 1 уровень";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level1NoMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: StartDialogKeyboards.SecondLevelKeyboard
                    );
                    break;
                case "StartDialog.2Level.Yes":
                    var level2YesMessage = "Положительный ответ 2 уровень (Приступаем к записи аудиосообщения)";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level2YesMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: StartDialogKeyboards.ThirdLevelKeyboard
                    );
                    break;
                case "StartDialog.2Level.No":
                    var level2NoMessage = "отрицательный ответ 2 уровень";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level2NoMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: StartDialogKeyboards.ThirdLevelKeyboard
                    );
                    break;
                case "StartDialog.3Level.Yes":
                    var level3YesMessage = "Положительный ответ 3 уровень (Приступаем к записи аудиосообщения)";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level3YesMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: StartDialogKeyboards.FinalLevelKeyborad
                    );
                    break;
                case "StartDialog.3Level.No":
                    var level3NoMessage = "Ничего не понял.(Приступаем к записи аудиосообщения)";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level3NoMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: StartDialogKeyboards.FinalLevelKeyborad
                    );
                    break;
            }
    }

 
}
