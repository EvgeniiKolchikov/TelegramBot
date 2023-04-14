using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram.StaticClasses;

public static class RecordsKeyboard
{
    public static InlineKeyboardMarkup AfterRecordKeyboard = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "Достаточно записей", callbackData: "EnoughRecords"),
        },
    });
}