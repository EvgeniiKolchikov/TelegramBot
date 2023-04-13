using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram.StaticClasses;

public static class StartDialogKeyboards
{
    public static readonly InlineKeyboardMarkup FirstLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да", callbackData: "StartDialog.1Level.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Не понял", callbackData: "StartDialog.1Level.No")
        },
    });
    
    public static InlineKeyboardMarkup SecondLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да", callbackData: "StartDialog.2Level.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Не понял", callbackData: "StartDialog.2Level.No")
        },
    });
    
    public static InlineKeyboardMarkup ThirdLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Да", callbackData: "StartDialog.3Level.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Не понял", callbackData: "StartDialog.3Level.No")
        },
    });
    
    public static InlineKeyboardMarkup FinalLevelKeyborad = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Достаточно записей", callbackData: "StartDialog.FinalLevel.Yes"),
            InlineKeyboardButton.WithCallbackData(text: "Начать заново", callbackData: "StartDialog.1Level.No")
        },
    });
}