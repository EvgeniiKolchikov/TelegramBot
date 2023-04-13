using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram.StaticClasses;

public static class DailyDialogKeyboards
{
    public static readonly InlineKeyboardMarkup FirstLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Умницей", callbackData: "DailyDialog.1Level.Yes"),
           // InlineKeyboardButton.WithCallbackData(text: "Пустая кнопка", callbackData: "DailyDialog.1Level.No")
        },
    });
    
    public static readonly InlineKeyboardMarkup SecondLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "1-3", callbackData: "DailyDialog.2Level.1-3"),
            InlineKeyboardButton.WithCallbackData(text: "4-7", callbackData: "DailyDialog.2Level.4-7"),
            InlineKeyboardButton.WithCallbackData(text: "8-10", callbackData: "DailyDialog.2Level.8-10")
        }
    });
    
    public static readonly InlineKeyboardMarkup ThirdLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Нет", callbackData: "DailyDialog.3Level.No")
        },
        new []
        {
             InlineKeyboardButton.WithCallbackData(text: "Да, записать текстовое воспоминание", callbackData: "DailyDialog.Yes.Text")
         },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, записать голосовое воспоминание", callbackData: "DailyDialog.Yes.Voice")
        }
    });
    
    public static readonly InlineKeyboardMarkup ThirdLevelKeyboard47 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Не хочу", callbackData: "DailyDialog.3Level.No")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, записать текстовое воспоминание", callbackData: "DailyDialog.Yes.Text")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, записать голосовое воспоминание", callbackData: "DailyDialog.Yes.Voice")
        }
    });
    
    public static readonly InlineKeyboardMarkup ThirdLevelKeyboard810 = new(new[]
    {
       new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Записать текст", callbackData: "DailyDialog.Yes.Text")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Записать аудио", callbackData: "DailyDialog.Yes.Voice")
        }
    });
    
    public static readonly InlineKeyboardMarkup FourthLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Нет, закончить сеанс", callbackData: "DailyDialog.4Level.No")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, записать текстовое воспоминание", callbackData: "DailyDialog.Yes.Text")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, записать голосовое воспоминание", callbackData: "DailyDialog.Yes.Voice")
        }
    });
}