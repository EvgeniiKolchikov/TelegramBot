using ImpostorHelp.Telegram.StaticClasses;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Dialogs;

public class DailyDialog
{
    public DailyDialog()
    {
        
    }

    public async Task DailyTextDialog(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;
        Console.WriteLine($"Received a '{update.Message.Text}' message in chat {update.Message.From.Username}.");
        var welcomeMessage = "Кем Вы сегодня были - самозванцем или  умницей?";
        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: welcomeMessage,
            cancellationToken: cancellationToken,
            replyMarkup: DailyDialogKeyboards.FirstLevelKeyboard
        );
    }
    
    public async Task DailyCallBackQueryDialog(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.CallbackQuery != null)
        {
            var chatId = update.CallbackQuery.From.Id;
            switch (update.CallbackQuery.Data)
            {
                case "DailyDialog.1Level.Yes":
                    var level1YesMessage = "Оцените степень удовлетворения собой по шкале от 1 до 10";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level1YesMessage,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyDialogKeyboards.SecondLevelKeyboard
                    );
                    break;
                
                
                
                case "DailyDialog.2Level.1-3" :
                    var level2Message13 = "Как вам кажется, опыт сегодняшнего дня вдохновит вас в будущем?";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level2Message13,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyDialogKeyboards.ThirdLevelKeyboard13
                    );
                    break;
                
                case "DailyDialog.2Level.4-7" :
                    var level2Message47 =
                        "То есть сегодняшний день может вселить уверенность на будущее, что не такой уж я и самозванец? \nДавай запишем себе напоминание об этом опыте";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level2Message47,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyDialogKeyboards.ThirdLevelKeyboard47
                    );
                    break;
                
                case "DailyDialog.2Level.8-10" :
                    var level2Message810 =
                        "!Круто! Такой опыт сможет вдохновить тебя в будущем, когда вернётся \"феномен самозванца\".\nДавай запишем сегодняшние эмоции в коллекцию!";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level2Message810,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyDialogKeyboards.ThirdLevelKeyboard810
                    );
                    break;

                case "DailyDialog.3Level.No":
                    var level3MessageNo =
                        "А может всё же записать? Ведь воспоминание о сегодняшнем успехе может помочь не унывать в будущем!";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level3MessageNo,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyDialogKeyboards.FourthLevelKeyboard
                    );
                    break;
                
                case "DailyDialog.4Level.No" :
                    var level4MessageNo = "Хорошо! Удачного дня вам завтра!";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level4MessageNo,
                        cancellationToken: cancellationToken
                    );
                    break;
                
                case "DailyDialog.Yes.Text" : 
                    var recordTextMessage = "Напиши текст, обращаясь к самому себе в будущее" +
                                            "\nШаг 1: опиши саму ситуацию, которая сегодня тебя укрепила в  своих профессиональных силах" +
                                            "\nШаг 2: расскажи, чем ты доволен в своих действиях?" +
                                            "\nШаг 3: какие чувства ты испытал, которые хочешь сохранить в своей памяти? ";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: recordTextMessage,
                        cancellationToken: cancellationToken
                    );
                    break;
                    
                
                case "DailyDialog.Yes.Voice" : 
                    var recordVoiceMessage = "Запиши аудио, обращаясь к самому себе в будущее";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: recordVoiceMessage,
                        cancellationToken: cancellationToken
                    );
                    break;
            }
        }
    }
}