using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram.StaticClasses;

public static class DailyDialogCommonKeyboards
{
    public static readonly InlineKeyboardMarkup FirstLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Умницей", callbackData: "DailyPositiveDialog.1Level"),
            InlineKeyboardButton.WithCallbackData(text: "Самозванцем", callbackData: "DailyNegativeDialog.1Level")
        },
    });
}