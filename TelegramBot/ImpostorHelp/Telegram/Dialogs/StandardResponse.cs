using ImpostorHelp.Telegram.StaticClasses;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Dialogs;

public class StandardResponse
{
    public async Task StandardCallBackQueryResponse(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (update.CallbackQuery != null)
        {
            var chatId = update.CallbackQuery.From.Id;
            switch (update.CallbackQuery.Data)
            {
                case "EnoughRecords":
                    var level1YesMessage = "Бот благодарит и желает хорошего дня!";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level1YesMessage,
                        cancellationToken: cancellationToken
                    );
                    break;

            }
        }
    }
}