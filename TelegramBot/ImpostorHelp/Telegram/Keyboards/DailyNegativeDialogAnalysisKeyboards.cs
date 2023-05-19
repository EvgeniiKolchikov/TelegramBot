using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram.Keyboards;

public static class DailyNegativeDialogAnalysisKeyboards
{
    public static readonly InlineKeyboardMarkup ThirdLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Давай", callbackData: "DailyNegativeDialog.3Level.1-3")
        }
    });
    
    public static readonly InlineKeyboardMarkup FourLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Готово, я написал(а)", callbackData: "DailyNegativeDialog.4Level.1-3")
        }
    });
    
    public static readonly InlineKeyboardMarkup FiveLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Прочитав, я вижу: в тексте только факты. Ай, да я! :)", callbackData: "DailyNegativeDialog.5Level.1-3.Facts")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Вижу в тексте оценки, поправил(а) текст", callbackData: "DailyNegativeDialog.5Level.1-3.Fix")
        }
    });
    
    public static readonly InlineKeyboardMarkup SixLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Готово, я написал(а)", callbackData: "DailyNegativeDialog.6Level.1-3")
        }
    });
    public static readonly InlineKeyboardMarkup SevenLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Готово, я написал(а)", callbackData: "DailyNegativeDialog.7Level.1-3")
        }
    });
    
    public static readonly InlineKeyboardMarkup EightLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Готово, я написал(а)", callbackData: "DailyNegativeDialog.8Level.1-3")
        }
    });
    
    public static readonly InlineKeyboardMarkup NineLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Готово, я написал(а)", callbackData: "DailyNegativeDialog.9Level.1-3")
        }
    });
    
    public static readonly InlineKeyboardMarkup TenLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "1", callbackData: "DailyNegativeDialog.10Level.01"),
            InlineKeyboardButton.WithCallbackData(text: "2", callbackData: "DailyNegativeDialog.10Level.02"),
            InlineKeyboardButton.WithCallbackData(text: "3", callbackData: "DailyNegativeDialog.10Level.03"),
            InlineKeyboardButton.WithCallbackData(text: "4", callbackData: "DailyNegativeDialog.10Level.04"),
            InlineKeyboardButton.WithCallbackData(text: "5", callbackData: "DailyNegativeDialog.10Level.05"),
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "6", callbackData: "DailyNegativeDialog.10Level.06"),
            InlineKeyboardButton.WithCallbackData(text: "7", callbackData: "DailyNegativeDialog.10Level.07"),
            InlineKeyboardButton.WithCallbackData(text: "8", callbackData: "DailyNegativeDialog.10Level.08"),
            InlineKeyboardButton.WithCallbackData(text: "9", callbackData: "DailyNegativeDialog.10Level.09"),
            InlineKeyboardButton.WithCallbackData(text: "10", callbackData: "DailyNegativeDialog.10Level.10")
        }
    });
    
    public static readonly InlineKeyboardMarkup ElevenLevelKeyboard13 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Способы,которыми я могу позаботиться о себе", callbackData: "DailyNegativeDialog.SelfHelp")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Посоветуй мне психолога", callbackData: "DailyNegativeDialog.Psychologist")
        }
    });
}