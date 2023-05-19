using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram.Keyboards;

public static class DailyNegativeDialogKeyboards
{
    public static readonly InlineKeyboardMarkup SecondLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "1", callbackData: "DailyNegativeDialog.2Level.1-3.01"),
            InlineKeyboardButton.WithCallbackData(text: "2", callbackData: "DailyNegativeDialog.2Level.1-3.02"),
            InlineKeyboardButton.WithCallbackData(text: "3", callbackData: "DailyNegativeDialog.2Level.1-3.03"),
            InlineKeyboardButton.WithCallbackData(text: "4", callbackData: "DailyNegativeDialog.2Level.4-7.04"),
            InlineKeyboardButton.WithCallbackData(text: "5", callbackData: "DailyNegativeDialog.2Level.4-7.05"),
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "6", callbackData: "DailyNegativeDialog.2Level.4-7.06"),
            InlineKeyboardButton.WithCallbackData(text: "7", callbackData: "DailyNegativeDialog.2Level.4-7.07"),
            InlineKeyboardButton.WithCallbackData(text: "8", callbackData: "DailyNegativeDialog.2Level.8-10.08"),
            InlineKeyboardButton.WithCallbackData(text: "9", callbackData: "DailyNegativeDialog.2Level.8-10.09"),
            InlineKeyboardButton.WithCallbackData(text: "10", callbackData: "DailyNegativeDialog.2Level.8-10.10")
        }
    });
    
    public static readonly InlineKeyboardMarkup SecondLevelKeyboardAfter810 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "1", callbackData: "DailyNegativeDialog.2Level.1-3.01"),
            InlineKeyboardButton.WithCallbackData(text: "2", callbackData: "DailyNegativeDialog.2Level.1-3.02"),
            InlineKeyboardButton.WithCallbackData(text: "3", callbackData: "DailyNegativeDialog.2Level.1-3.03"),
            InlineKeyboardButton.WithCallbackData(text: "4", callbackData: "DailyNegativeDialog.2Level.4-7.04"),
            InlineKeyboardButton.WithCallbackData(text: "5", callbackData: "DailyNegativeDialog.2Level.4-7.05"),
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "6", callbackData: "DailyNegativeDialog.2Level.4-7.06"),
            InlineKeyboardButton.WithCallbackData(text: "7", callbackData: "DailyNegativeDialog.2Level.4-7.07"),
            InlineKeyboardButton.WithCallbackData(text: "8", callbackData: "DailyNegativeDialog.3Level.8-10.08"),
            InlineKeyboardButton.WithCallbackData(text: "9", callbackData: "DailyNegativeDialog.3Level.8-10.09"),
            InlineKeyboardButton.WithCallbackData(text: "10", callbackData: "DailyNegativeDialog.3Level.8-10.10")
        }
    });
    
    public static readonly InlineKeyboardMarkup ThirdLevelKeyboard47 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Хочу провести анализ ситуации", callbackData: "DailyNegativeDialog.3Level.1-3")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Поддержите меня!", callbackData: "DailyNegativeDialog.Yes.SupportMe")
        }
    });
    
    public static readonly InlineKeyboardMarkup FourLevelKeyboard810WithAchievements = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Хочу освежить память о своих достижениях", callbackData: "DailyPositiveDialog.3Level.Get")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Поддержи меня как умеешь!", callbackData: "DailyPositiveDialog.Yes.SupportMe")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Посоветуй мне психолога", callbackData: "DailyNegativeDialog.Psychologist")
        }
    });
    
    public static readonly InlineKeyboardMarkup FourLevelKeyboard810WithoutAchievements = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Хочу освежить память о своих достижениях", callbackData: "DailyPositiveDialog.3Level.Get")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Поддержи меня как умеешь!", callbackData: "DailyPositiveDialog.Yes.SupportMe")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Посоветуй мне психолога", callbackData: "DailyNegativeDialog.Psychologist")
        }
    });
}