using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram.StaticClasses;

public static class DailyPositiveDialogKeyboards
{
   
    public static readonly InlineKeyboardMarkup SecondLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "1", callbackData: "DailyPositiveDialog.2Level.1-3"),
            InlineKeyboardButton.WithCallbackData(text: "2", callbackData: "DailyPositiveDialog.2Level.1-3"),
            InlineKeyboardButton.WithCallbackData(text: "3", callbackData: "DailyPositiveDialog.2Level.1-3"),
            InlineKeyboardButton.WithCallbackData(text: "4", callbackData: "DailyPositiveDialog.2Level.4-7"),
            InlineKeyboardButton.WithCallbackData(text: "5", callbackData: "DailyPositiveDialog.2Level.4-7"),
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "6", callbackData: "DailyPositiveDialog.2Level.4-7"),
            InlineKeyboardButton.WithCallbackData(text: "7", callbackData: "DailyPositiveDialog.2Level.4-7"),
            InlineKeyboardButton.WithCallbackData(text: "8", callbackData: "DailyPositiveDialog.2Level.8-10"),
            InlineKeyboardButton.WithCallbackData(text: "9", callbackData: "DailyPositiveDialog.2Level.8-10"),
            InlineKeyboardButton.WithCallbackData(text: "10", callbackData: "DailyPositiveDialog.2Level.8-10")
        }
    });
    
    public static readonly InlineKeyboardMarkup ThirdLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "1", callbackData: "DailyPositiveDialog.3Level.1-3"),
            InlineKeyboardButton.WithCallbackData(text: "2", callbackData: "DailyPositiveDialog.3Level.1-3"),
            InlineKeyboardButton.WithCallbackData(text: "3", callbackData: "DailyPositiveDialog.3Level.1-3"),
            InlineKeyboardButton.WithCallbackData(text: "4", callbackData: "DailyPositiveDialog.2Level.4-7"),
            InlineKeyboardButton.WithCallbackData(text: "5", callbackData: "DailyPositiveDialog.2Level.4-7"),
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "6", callbackData: "DailyPositiveDialog.2Level.4-7"),
            InlineKeyboardButton.WithCallbackData(text: "7", callbackData: "DailyPositiveDialog.2Level.4-7"),
            InlineKeyboardButton.WithCallbackData(text: "8", callbackData: "DailyPositiveDialog.2Level.8-10"),
            InlineKeyboardButton.WithCallbackData(text: "9", callbackData: "DailyPositiveDialog.2Level.8-10"),
            InlineKeyboardButton.WithCallbackData(text: "10", callbackData: "DailyPositiveDialog.2Level.8-10")
        }
    });
    
    public static readonly InlineKeyboardMarkup ThirdLevelKeyboard47 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Я не в настроении", callbackData: "DailyPositiveDialog.4Level.No")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, записать текстовое воспоминание", callbackData: "DailyPositiveDialog.Yes.Text")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, записать голосовое воспоминание", callbackData: "DailyPositiveDialog.Yes.Voice")
        }
    });
    
    public static readonly InlineKeyboardMarkup ThirdLevelKeyboard810 = new(new[]
    {
       new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Записать текст", callbackData: "DailyPositiveDialog.Yes.Text")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Записать аудио", callbackData: "DailyPositiveDialog.Yes.Voice")
        }
    });
    
    public static readonly InlineKeyboardMarkup FourthLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Нет", callbackData: "DailyPositiveDialog.4Level.No")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, создать текстовое воспоминание", callbackData: "DailyPositiveDialog.Yes.Text")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, записать голосовое воспоминание", callbackData: "DailyPositiveDialog.Yes.Voice")
        }
    });
    
    public static readonly InlineKeyboardMarkup FiveLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Нет, закончить сеанс", callbackData: "DailyPositiveDialog.5Level.No")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, создать текстовое воспоминание", callbackData: "DailyPositiveDialog.Yes.Text")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, записать голосовое воспоминание", callbackData: "DailyPositiveDialog.Yes.Voice")
        }
    });
    
    public static readonly InlineKeyboardMarkup SixLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Сохранить и закончить", callbackData: "DailyPositiveDialog.Exit")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Добавить изображение", callbackData: "DailyPositiveDialog.Picture")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Сделать еще запись", callbackData: "DailyPositiveDialog.7Level.AddMoreRecord")
        }
    });
    
    public static readonly InlineKeyboardMarkup ExitKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Сохранить и закончить", callbackData: "DailyPositiveDialog.Exit")
        }
    });
}