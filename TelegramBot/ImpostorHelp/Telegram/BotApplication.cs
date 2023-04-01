using ImpostorHelp.Context;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ImpostorHelp.Telegram;

public class BotApplication
{
    private ApplicationContext _db;
    public BotApplication()
    {
        _db = new ApplicationContext();
    }

    private void Foo()
    {
        Console.WriteLine("Hello");
    }

    public void Run()
    {
        Foo();
    }
}