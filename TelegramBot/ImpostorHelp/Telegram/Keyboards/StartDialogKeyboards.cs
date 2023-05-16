using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram.Keyboards;

public static class StartDialogKeyboards
{
    public static readonly InlineKeyboardMarkup FirstLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, знаю не понаслышке!", callbackData: "StartDialog.1Level.Yes"),
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Нет, расскажи", callbackData: "StartDialog.1Level.No")
        }
    });
    
    public static InlineKeyboardMarkup SecondLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, это мне знакомо", callbackData: "StartDialog.2Level.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Думаю, нет", callbackData: "StartDialog.2Level.No")
        },
    });
    
    public static InlineKeyboardMarkup ThirdLevelKeyboard1 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Приступим", callbackData: "StartDialog.3Level.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Нет, я передумал", callbackData: "StartDialog.Bye")
        },
    });
    public static InlineKeyboardMarkup ThirdLevelKeyboard2 = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Давай попробуем!", callbackData: "StartDialog.3Level.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Нет, я не хочу", callbackData: "StartDialog.Bye")
        },
    });
    
    public static InlineKeyboardMarkup FourthLevelKeyborad = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Мне всё понятно, что дальше?", callbackData: "StartDialog.4Level.Yes"),
        }
    });
    
    public static InlineKeyboardMarkup FiveLevelKeyborad = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "00:00", callbackData: "StartDialog.5Level.Time.00:00"),
            InlineKeyboardButton.WithCallbackData(text: "01:00", callbackData: "StartDialog.5Level.Time.01:00"),
            InlineKeyboardButton.WithCallbackData(text: "02:00", callbackData: "StartDialog.5Level.Time.02:00"),
            InlineKeyboardButton.WithCallbackData(text: "03:00", callbackData: "StartDialog.5Level.Time.03:00"),
            InlineKeyboardButton.WithCallbackData(text: "04:00", callbackData: "StartDialog.5Level.Time.04:00"),
            InlineKeyboardButton.WithCallbackData(text: "05:00", callbackData: "StartDialog.5Level.Time.05:00")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "06:00", callbackData: "StartDialog.5Level.Time.06:00"),
            InlineKeyboardButton.WithCallbackData(text: "07:00", callbackData: "StartDialog.5Level.Time.07:00"),
            InlineKeyboardButton.WithCallbackData(text: "08:00", callbackData: "StartDialog.5Level.Time.08:00"),
            InlineKeyboardButton.WithCallbackData(text: "09:00", callbackData: "StartDialog.5Level.Time.09:00"),
            InlineKeyboardButton.WithCallbackData(text: "10:00", callbackData: "StartDialog.5Level.Time.10:00"),
            InlineKeyboardButton.WithCallbackData(text: "11:00", callbackData: "StartDialog.5Level.Time.11:00")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "12:00", callbackData: "StartDialog.5Level.Time.12:00"),
            InlineKeyboardButton.WithCallbackData(text: "13:00", callbackData: "StartDialog.5Level.Time.13:00"),
            InlineKeyboardButton.WithCallbackData(text: "14:00", callbackData: "StartDialog.5Level.Time.14:00"),
            InlineKeyboardButton.WithCallbackData(text: "15:00", callbackData: "StartDialog.5Level.Time.15:00"),
            InlineKeyboardButton.WithCallbackData(text: "16:00", callbackData: "StartDialog.5Level.Time.16:00"),
            InlineKeyboardButton.WithCallbackData(text: "17:00", callbackData: "StartDialog.5Level.Time.17:00")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "18:00", callbackData: "StartDialog.5Level.18:00"),
            InlineKeyboardButton.WithCallbackData(text: "19:00", callbackData: "StartDialog.5Level.19:00"),
            InlineKeyboardButton.WithCallbackData(text: "20:00", callbackData: "StartDialog.5Level.20:00"),
            InlineKeyboardButton.WithCallbackData(text: "21:00", callbackData: "StartDialog.5Level.21:00"),
            InlineKeyboardButton.WithCallbackData(text: "22:00", callbackData: "StartDialog.5Level.22:00"),
            InlineKeyboardButton.WithCallbackData(text: "23:00", callbackData: "StartDialog.5Level.23:00")
        }
    });
    
    public static InlineKeyboardMarkup SixLevelKeyborad = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, я хочу записать воспоминание текстом", callbackData: "StartDialog.6Level.Text"),
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да, я хочу записать аудио-воспоминание", callbackData: "StartDialog.6Level.Audio"),
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Нет, я не хочу сейчас ничего записывать", callbackData: "StartDialog.6Level.No"),
        }
    });
    
    public static InlineKeyboardMarkup SevenLevelKeyboradText = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Написал(а)", callbackData: "StartDialog.8Level.Ok")
        }
    });
    
    public static InlineKeyboardMarkup SevenLevelKeyboradAudio = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Записал(а)", callbackData: "StartDialog.8Level.Ok")
        }
    });
    
    public static InlineKeyboardMarkup SevenLevelKeyboardNo = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Я передумал(а). Давай напишу поддерживающий текст!", callbackData: "StartDialog.6Level.Text")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Я передумал(а), всё-таки хочу записать поддерживающее аудио!", callbackData: "StartDialog.6Level.Audio")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Хорошо. До встречи!", callbackData: "StartDialog.Bye")
        }
    });
    
    public static InlineKeyboardMarkup NineLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Хочу записать ещё текст!", callbackData: "StartDialog.9Level.Text")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Хочу записать ещё аудио!", callbackData: "StartDialog.9Level.Audio")
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Пожалуй, остановлюсь на этом. До завтра!", callbackData: "StartDialog.Bye")
        }
    });
    
    public static InlineKeyboardMarkup TenthLevelKeyboradText = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Написал(а)", callbackData: "StartDialog.10Level.Ok")
        }
    });
    
    public static InlineKeyboardMarkup TenthLevelKeyboradAudio = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Записал(а)", callbackData: "StartDialog.10Level.Ok")
        }
    });
}