using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Handlers;

public class HelpMessageSender
{
    public async Task SendHelpMessage(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var message = "Если у вас возникли вопросы при использовании бота Антисамозванец, пишите нам, авторам бота. " +
                      "Мы простараемся помочь!" +
                      "\n \nhttps://t.me/imposter_help";

        await botClient.SendTextMessageAsync(
            chatId:update.Message.Chat.Id,
            message,
            cancellationToken:cancellationToken
        );
    }
}