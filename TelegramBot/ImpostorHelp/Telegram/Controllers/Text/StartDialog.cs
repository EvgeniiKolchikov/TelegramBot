using System.Diagnostics;
using ImpostorHelp.Repositories;
using ImpostorHelp.Telegram.Models;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram.Controllers.Text;

public class StartDialog
{
    private readonly IChatRepository _chatRepository;
    private readonly JObject _sentence;
    private Dictionary<long, UserState> _userStates = new Dictionary<long, UserState>();
    public StartDialog(JObject sentence)
    {
        _sentence = sentence;
        _chatRepository = new ChatRepository();
    }
    
    public async Task StartingDialog (ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        
        if (update.Type == UpdateType.Message)
        {
            var chatId = update.Message.Chat.Id;
            Console.WriteLine($"Received a '{update.Message.Text}' message in chat {chatId}.");
            var startMessage = "Добро пожаловать. Стартовое сообщение с описанием и вариантами ответа";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: startMessage,
                cancellationToken: cancellationToken,
                replyMarkup: firstLevelKeyboard
            );
        }

        if (update.Type == UpdateType.CallbackQuery)
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
                        replyMarkup: secondLevelKeyboard
                    );
                    break;
                case "StartDialog.1Level.No":
                    var level1NoMessage = "отрицательный ответ 1 уровень";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level1NoMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: secondLevelKeyboard
                    );
                    break;
                case "StartDialog.2Level.Yes":
                    var level2YesMessage = "Положительный ответ 2 уровень (Приступаем к записи аудиосообщения)";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level2YesMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: thirdLevelKeyboard
                    );
                    break;
                case "StartDialog.2Level.No":
                    var level2NoMessage = "отрицательный ответ 2 уровень";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level2NoMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: thirdLevelKeyboard
                    );
                    break;
                case "StartDialog.3Level.Yes":
                    var level3YesMessage = "Положительный ответ 3 уровень (Приступаем к записи аудиосообщения)";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level3YesMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: finalLevelKeyborad
                    );
                    break;
                case "StartDialog.3Level.No":
                    var level3NoMessage = "Ничего не понял.(Приступаем к записи аудиосообщения)";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level3NoMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: finalLevelKeyborad
                    );
                    break;
            }
        }
    }

    private InlineKeyboardMarkup firstLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да", callbackData: "StartDialog.1Level.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Не понял", callbackData: "StartDialog.1Level.No")
        },
    });
    
    private InlineKeyboardMarkup secondLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да", callbackData: "StartDialog.2Level.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Не понял", callbackData: "StartDialog.2Level.No")
        },
    });
    
    private InlineKeyboardMarkup thirdLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да", callbackData: "StartDialog.3Level.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Не понял", callbackData: "StartDialog.3Level.No")
        },
    });
    
    private InlineKeyboardMarkup finalLevelKeyborad = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Достаточно записей", callbackData: "StartDialog.FinalLevel.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Начать заново", callbackData: "StartDialog.1Level.No")
        },
    });
}
