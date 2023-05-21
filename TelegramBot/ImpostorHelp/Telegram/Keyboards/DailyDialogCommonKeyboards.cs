using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram.StaticClasses;

public static class DailyDialogCommonKeyboards
{
    public static readonly InlineKeyboardMarkup FirstLevelKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Я скорее умница!", callbackData: "DailyPositiveDialog.1Level"),
            InlineKeyboardButton.WithCallbackData(text: "Чувствую себя самозванцем :(", callbackData: "DailyNegativeDialog.1Level")
        },
    });
}