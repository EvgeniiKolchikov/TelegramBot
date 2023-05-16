using ImpostorHelp.Database.Interfaces;
using ImpostorHelp.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Handlers;

public class TextMessageHandler
{
    private readonly ITextMessageRepository _textMessageRepository;
    public TextMessageHandler()
    {
        _textMessageRepository = new TextMessageRepository();
    }

    public async Task AddTextMessage(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (update.Message != null)
        {
            var chatId = update.Message.Chat.Id;
            if (update.Message.Text != null)
            {
                await _textMessageRepository.AddTextMessageToDb(chatId, update.Message.Text);
            }

            await botClient.DeleteMessageAsync(chatId, update.Message.MessageId, cancellationToken);
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Воспоминание сохранено",
                cancellationToken: cancellationToken
            );
        }
    }
}