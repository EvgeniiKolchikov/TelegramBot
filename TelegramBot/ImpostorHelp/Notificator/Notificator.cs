using System.Threading.Channels;
using ImpostorHelp.Context;
using ImpostorHelp.Telegram.StaticClasses;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

namespace ImpostorHelp.Notificator;

public class Notificator
{
    private ApplicationContext _db;
    private DateTime _now;

    public Notificator()
    {
        _db = new ApplicationContext();
        _now = DateTime.UtcNow + TimeSpan.FromHours(3);
    }

    private List<long> GetChatIdList()
    {
        var res = _db.Chats.Where(c => c.NotificationTime.Hour == _now.Hour
                                       && c.NotificationTime.Minute == _now.Minute)
            .Select(c => c.ChatId).ToList();
        return res;
    }

    public async Task NoticeAsync(ITelegramBotClient botClient)
    {
        while (true)
        {
            _now = DateTime.UtcNow + TimeSpan.FromHours(3);
            Console.WriteLine(_now);
            var res = await _db.Chats.Where(c => c.NotificationTime.Hour == _now.Hour
                                                 && c.NotificationTime.Minute == _now.Minute)
                .Select(c => c.ChatId).ToListAsync();
            foreach (var chatId in res)
            {
                var welcomeMessage = "Кем Вы сегодня были - самозванцем или  умницей?";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: welcomeMessage,
                    replyMarkup: DailyDialogCommonKeyboards.FirstLevelKeyboard
                );
            }
            Thread.Sleep(60000);
        }
    }

}