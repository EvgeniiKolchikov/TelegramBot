using ImpostorHelp.Telegram.Keyboards;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Dialogs;

/// <summary>
/// негативный сценарий ежедневного диалога
/// </summary>
public class DailyNegativeDialog
{
    public async Task DailyNegativeCallBackQueryDialog(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.CallbackQuery != null)
        {
            var chatId = update.CallbackQuery.From.Id;

            switch (update.CallbackQuery.Data)
            {
                case "DailyNegativeDialog.1Level":
                    var level1Message = "Оцените степень недовольства собой по шкале от 1 до 10 (где 1 - это легкие сомнения, а 10 - ощущение себя полным ничтожеством)";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level1Message,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyNegativeDialogKeyboards.SecondLevelKeyboard
                    );
                    break;
                
                case "DailyNegativeDialog.2Level.1-3" :
                    var level2Message13 = "Давай разберём ситуацию, и посмотрим, как ты можешь поддержать себя";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level2Message13,
                        cancellationToken: cancellationToken
                        //replyMarkup: DailypositiveDialogKeyboards.ThirdLevelKeyboard13
                    );
                    break;
                
                case "DailyNegativeDialog.2Level.4-7" :
                    var level2Message47 =
                        "Ты хочешь разобрать ситуацию или получить поддержку?";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level2Message47,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyNegativeDialogKeyboards.ThirdLevelKeyboard47
                    );
                    break;
                
                case "DailyNegativeDialog.2Level.8-10" :
                    var level2Message810 =
                        " Люди, подверженные Синдрому самозванца часто склонны преувеличивать ужас неудач.\n Дай себе минутку на размышление: может быть ты переоцениваешь своё состояние? 😉 \n Итак, сегодня ты страдал от синдрома самозванца на...";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level2Message810,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyNegativeDialogKeyboards.SecondLevelKeyboardAfter810
                    );
                    break;
                
                //todo - dailynegative dialog добавить для левой стороны схемы описание
                
                case "DailyNegativeDialog.3Level.8-10" :
                    var level3Message810 =
                        " Блин! Очень Жаль... Что может помочь тебе сейчас лучше всего?";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: level3Message810,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyNegativeDialogKeyboards.FourLevelKeyboard810
                    );
                    break;
            }
        }
    }
}