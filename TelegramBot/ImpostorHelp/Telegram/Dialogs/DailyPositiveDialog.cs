using ImpostorHelp.Telegram.Handlers;
using ImpostorHelp.Telegram.StaticClasses;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Dialogs;

/// <summary>
/// Класс для позитивного диалога
/// </summary>
public class DailyPositiveDialog
{
    private UserPositiveChoiceRecordHandler _handler;

    public DailyPositiveDialog()
    {
        _handler = new UserPositiveChoiceRecordHandler();
    }
    
    public async Task DailyPositiveCallBackQueryDialog(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.CallbackQuery != null && update.CallbackQuery.Data != null)
        {
            var chatId = update.CallbackQuery.From.Id;
            if (update.CallbackQuery.Data == "DailyPositiveDialog.1Level")
            {
                var level1YesMessage = "Здорово! Если оценить это чувство по шкале от 1 до 10, где 1 — минимальное принятие своих достижений, " +
                                       "а 10 - полноценная уверенность в том, что ты и есть причина своих успехов, какую оценку ты поставишь?";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level1YesMessage,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyPositiveDialogKeyboards.SecondLevelKeyboard
                );
            }
            else if (update.CallbackQuery.Data.Contains("DailyPositiveDialog.2Level.1-3"))
            {
                var level2Message13 = " Люди, подверженные феномену самозванца часто склонны занижать значимость своих успехов." +
                                      " Дай себе минутку на размышления: возможно, ты недооцениваешь сегодняшний день? 😉" +
                                      "\nИтак, сегодня ты можешь полностью присвоить себе свои достижения на...";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level2Message13,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyPositiveDialogKeyboards.ThirdLevelKeyboard13
                );
            }
            else if (update.CallbackQuery.Data.Contains("DailyPositiveDialog.2Level.4-7"))
            {
                await _handler.SaveChoiceAsync(update.CallbackQuery.From.Id,update.CallbackQuery.Data);
                var level2Message47 = "То есть сегодняшний день может вселить уверенность на будущее, что не такой уж я и самозванец? " +
                                      "\nДавай запишем себе напоминание об этом опыте То есть сегодняшний день может вселить уверенность в будущем, что не такой уж я и самозванец? Класс! Давай запишем себе напоминание об этом опыте." +
                                      "\n \nВыбери формат, в котором зафиксируешь момент:";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level2Message47,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyPositiveDialogKeyboards.ThirdLevelKeyboard47
                );
            }
            else if (update.CallbackQuery.Data.Contains("DailyPositiveDialog.2Level.8-10"))
            {
                await _handler.SaveChoiceAsync(update.CallbackQuery.From.Id,update.CallbackQuery.Data);
                var level2Message810 =
                    "Круто! Такой опыт сможет вдохновить тебя в будущем, если самозванец постучится в дверь. Давай сохраним сегодняшние эмоции в коллекцию!" +
                    "\n \nВыбери формат, в котором зафиксируешь момент:";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level2Message810,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyPositiveDialogKeyboards.ThirdLevelKeyboard810
                );
            }
            else if (update.CallbackQuery.Data.Contains("DailyPositiveDialog.3Level.1-3"))
            {
                await _handler.SaveChoiceAsync(update.CallbackQuery.From.Id,update.CallbackQuery.Data);
                var level3MessageNo =
                    "Принято. Как ты думаешь, опыт сегодняшнего дня может вдохновить тебя в будущем?";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level3MessageNo,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyPositiveDialogKeyboards.FourthLevelKeyboard
                );
            }
            else if (update.CallbackQuery.Data == "DailyPositiveDialog.4Level.No")
            {
                var level4MessageNo = " Выбор за тобой. Помни, что даже небольшой успех может здорово подбодрить тебя в будущем. " +
                                      "\n \nМожет всё же сохраним его в памяти?";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level4MessageNo,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyPositiveDialogKeyboards.FiveLevelKeyboard
                );
            }
            
            else if (update.CallbackQuery.Data == "DailyPositiveDialog.5Level.No")
            {
                var level4MessageNo = " Договорились! Удачного тебе дня! ";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level4MessageNo,
                    cancellationToken: cancellationToken
                );
            }
            
            else if (update.CallbackQuery.Data == "DailyPositiveDialog.Yes.Text")
            {
                var recordTextMessage = "Напиши текст, обращаясь к самому себе. " +
                                        "\nТекст должен начинаться со слов \"Воспоминание:\"" +
                                        "\nШаг 1: опиши саму ситуацию, которая сегодня тебя укрепила в  своих профессиональных силах" +
                                        "\nШаг 2: расскажи, чем ты доволен в своих действиях?" +
                                        "\nШаг 3: какие чувства ты испытал, которые хочешь сохранить в своей памяти? ";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: recordTextMessage,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyPositiveDialogKeyboards.SixLevelKeyboard
                );
            }
            else if (update.CallbackQuery.Data == "DailyPositiveDialog.Yes.Voice")
            {
                var recordVoiceMessage = "Запиши аудио, обращаясь к самому себе." +
                                         "\n \nШаг 1: что именно с тобой произошло, что подтвердило твою состоятельность?" +
                                         "\nШаг 2: какие твои действия помогли тебе почувствовать удовлетворенность собой?" +
                                         "\nШаг 3: какие чувства, связанные с событием, ты хочешь сохранить в своей памяти?";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: recordVoiceMessage,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyPositiveDialogKeyboards.SixLevelKeyboard
                );
            }
            
            else if (update.CallbackQuery.Data == "DailyPositiveDialog.Picture")
            {
                var recordVoiceMessage = "Загрузи фотографию, которая напомнит тебе об эмоциях сегодняшнего дня. " +
                                         "\nЭто может быть фото сертификата, скриншот отзыва или любая деталь, важная для тебя в моменте.";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: recordVoiceMessage,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyPositiveDialogKeyboards.ExitKeyboard
                );
            }
            
            else if (update.CallbackQuery.Data == "DailyPositiveDialog.7Level.AddMoreRecord")
            {
                var recordVoiceMessage = "Если сегодня было ещё событие, которое укрепило твою веру в себя, опиши и его по тому же алгоритму:" +
                                         "\nШаг 1: Ситуация" +
                                         "\nШаг 2: Твои успешные действия" +
                                         "\nШаг 3: Чувства относительно всего этого";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: recordVoiceMessage,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyPositiveDialogKeyboards.ExitKeyboard
                );
            }
            
            else if (update.CallbackQuery.Data == "DailyPositiveDialog.Exit")
            {
                var recordVoiceMessage = "Отлично! Это важно, фиксировать подобные моменты. Напомню тебе о них в будущем." +
                                         "\nЗапись успешно сохранена в библиотеку, а мы с тобой чуть ближе к ощущению \"ум-ни-цы\"." +
                                         "\n \nДо завтра!";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: recordVoiceMessage,
                    cancellationToken: cancellationToken
                );
            }
        }
    }
}