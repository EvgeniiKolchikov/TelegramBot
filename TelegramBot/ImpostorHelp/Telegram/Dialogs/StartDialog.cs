using ImpostorHelp.Telegram.Keyboards;
using ImpostorHelp.Telegram.StaticClasses;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Dialogs;

public class StartDialog
{
    private readonly IChatRepository _chatRepository;
    private readonly IVoiceMessageRepository _voiceMessageRepository;
    private readonly JObject _sentence;

    public StartDialog(IChatRepository chatRepository, IVoiceMessageRepository voiceMessageRepository)
    {
        _chatRepository = chatRepository;
        _voiceMessageRepository = voiceMessageRepository;
    }
    
    public async Task StartingTextDialog (ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;
        Console.WriteLine($"Received a '{update.Message.Text}' message in chat {chatId}.");
        var startMessage = "Привет! Я - бот \"Антисамозванец.\" " +
                           "\nПредполагаю, что тебя привело сюда желание улучшить свою жизнь или чистое любопытство. В любом случае, думаю, что смогу подсветить что-то важное для тебя. " +
                           "\nЯ создан, чтобы помочь тебе справляться с феноменом самозванца." +
                           "\nЗнаешь ли ты, что такое феномен самозванца?";
        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: startMessage,
            cancellationToken: cancellationToken,
            replyMarkup: StartDialogKeyboards.FirstLevelKeyboard
        );
    }

    public async Task StartingCallBackQueryDialog(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var chatId = update.CallbackQuery.From.Id;
        if (update.CallbackQuery.Data == "StartDialog.1Level.Yes")
        {
            var level1YesMessage = "Круто, что ты знаешь! Грустно, что не понаслышке..." +
                                   "\nНо всё-таки давай проверим, сходятся ли наши представления. Человек, подверженный феномену самозванца, чувствует себя недостаточно компетентным и склонен обесценивать свои достижения." +
                                   "\nБывало ли с тобой такое?";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: level1YesMessage,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.SecondLevelKeyboard
            );
        }
        else if (update.CallbackQuery.Data == "StartDialog.1Level.No")
        {
            var level1NoMessage =
                "Если коротко, то человек, подверженный феномену самозванца, чувствует себя недостаточно компетентным и склонен обесценивать свои достижения. " +
                "\nБывало ли с тобой такое?";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: level1NoMessage,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.SecondLevelKeyboard
            );
        }
        else if (update.CallbackQuery.Data == "StartDialog.2Level.Yes")
        {
            var level2YesMessage = "Понимаю. Ощущать это неприятно, но я здесь неспроста! " +
                                   "\nБританские учёные нашептали мне, что феномен самозванца — это ошибка мышления. Если ты сможешь немного изменить привычное восприятие себя и мира, то у тебя получится не поддаваться влиянию феномена самозванца." +
                                   "\nПриступим?";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: level2YesMessage,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.ThirdLevelKeyboard1
            );
        }
        else if (update.CallbackQuery.Data == "StartDialog.2Level.No")
        {
            var level2NoMessage =
                "Отличная новость! Если для тебя это действительно неактуально, то ты можешь не прибегать к моей помощи." +
                "\nНо знай, что техники, которые я предлагаю, могут быть полезны любому человеку, даже если он не ощущает влияние феномена самозванца." +
                "\nЕсли ты всё-таки решишь поработать со мной, опирайся на свои ощущения. При желании в любой момент ты сможешь закончить." +
                "\nПродолжим?";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: level2NoMessage,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.ThirdLevelKeyboard2
            );
        }
        else if (update.CallbackQuery.Data == "StartDialog.3Level.Yes")
        {
            var level3YesMessage = "Как именно я могу тебе помочь? " +
                                   "\nКаждый день я буду присылать тебе уведомления и просить оценить уровень присутствия самозванца в твоей голове." +
                                   "\nВ зависимости от твоего состояния в моменте, ты сможешь выбрать те техники самопомощи, которые будут актуальны." +
                                   "\nБлагодаря им ты сможешь:" +
                                   "\n— учиться опираться на себя и присваивать свой успех;" +
                                   "\n— лучше понять (и простить) феномен самозванца;" +
                                   "\n— получить поддержку от создателей ботап (потому что и им не понаслышке знаком этот феномен);" +
                                   "\n— потренироваться распознавать ошибки мышления и справляться с ними." +
                                   "\n\nОсторожно! Побочным эффектом общения со мной может  быть то, что ты станешь добрее к себе :)" +
                                   "\nЯ очень постараюсь быть тебе полезным, но помни, что я всего лишь бот, и, если тебе понадобится более серьезная помощь, лучше обратиться к психологу.";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: level3YesMessage,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.FourthLevelKeyborad
            );
        }
        else if (update.CallbackQuery.Data == "StartDialog.3Level.No")
        {
            var level3NoMessage = "Пока пока";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: level3NoMessage,
                cancellationToken: cancellationToken
            );
        }
        else if (update.CallbackQuery.Data == "StartDialog.4Level.Yes")
        {
            var level4Message =
                "Чтобы я присылал тебе уведомления тогда, когда это будет удобно, пожалуйста, выбери подходящее время. " +
                "\nНиже указано время по московскому часовому поясу (GMT+3). Выбери тот час, в который ты скорее всего сможешь со мной пообщаться." +
                "\nПри необходимости ты сможешь поменять время в настройках.";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: level4Message,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.FiveLevelKeyborad
            );
        }
        else if (update.CallbackQuery.Data.Contains("StartDialog.5Level."))
        {
            var level5Message = "Договорились! " +
                                "\nОстался заключительный шаг до нашей следующей встречи." +
                                "\nОдин из способов самопомощи при феномене самозванца — это обращение к собственным воспоминаниям успеха. Я говорю о тех моментах, когда ты чувствуешь себя компетентно, уверенно, когда самозванец не нашёптывает в твоё ухо вещи, которые заставляют сомневаться в себе." +
                                "\nЧтобы я точно смог помочь, если это понадобится даже завтра, я предлагаю тебе уже сейчас подготовить небольшую копилку таких опорных воспоминаний." +
                                "\nСможешь выделить сейчас на это 5-15 минут?";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: level5Message,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.SixLevelKeyborad
            );
        }
        
        else if (update.CallbackQuery.Data == "StartDialog.6Level.Text")
        {
            var level6Message = "Напиши текст, обращаясь к себе в будущее. Текст должен начинатьсо со слов \"Воспоминание:\" " +
                                "\n\nШаг 1: что именно с тобой произошло, что подтвердило твою состоятельность?" +
                                "\nШаг 2: какие твои действия помогли тебе почувствовать удовлетворенность собой?" +
                                "\nШаг 3: какие чувства, связанные с событием, ты хочешь сохранить в своей памяти?";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: level6Message,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.SevenLevelKeyboradText
            );
        }
        
        else if (update.CallbackQuery.Data == "StartDialog.6Level.Audio")
        {
            var level6Message = "Запиши аудио, обращаясь к себе в будущее." +
                                "\n\nШаг 1: что именно с тобой произошло, что подтвердило твою состоятельность?" +
                                "\nШаг 2: какие твои действия помогли тебе почувствовать удовлетворенность собой?" +
                                "\nШаг 3: какие чувства, связанные с событием, ты хочешь сохранить в своей памяти?";
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: level6Message,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.SevenLevelKeyboradAudio
            );
        }
        
        else if (update.CallbackQuery.Data == "StartDialog.6Level.No")
        {
            var message = "Я понимаю тебя: сходу вспомнить ситуацию своего успеха, когда пришел в бот \"Антисамозванец\", может быть сложно :)" +
                "\nМы можем остановиться здесь и пообщаться при следующей встрече. Если завтра тебе понадобится поддержка, я постараюсь помочь тебе другими способами." +
                "\n\nПока!";

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: message,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.SevenLevelKeyboardNo
            );
        }
        
        else if (update.CallbackQuery.Data == "StartDialog.8Level.Ok")
        {
            var message = "Супер! Если хочешь, можно записать ещё одно воспоминание. Чтобы уже записанному не было одиноко в твоей библиотеке :)" +
                          "\n\nЛибо мы можем попрощаться до завтра!";

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: message,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.NineLevelKeyboard
            );
        }
        
        else if (update.CallbackQuery.Data == "StartDialog.9Level.Text")
        {
            var message = "Напиши текст, обращаясь к себе в будущее. Текст должен начинатьсо со слов \"Воспоминание:\"" +
                          "\n\nШаг 1: Ситуация" +
                          "\nШаг 2: Твои успешные действия" +
                          "\nШаг 3: Чувства относительно всего этого";

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: message,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.TenthLevelKeyboradText
            );
        }
        
        else if (update.CallbackQuery.Data == "StartDialog.9Level.Audio")
        {
            var message = "Запиши аудио, обращаясь к себе в будущее." +
                          "\nШаг 1: Ситуация" +
                          "\nШаг 2: Твои успешные действия" +
                          "\nШаг 3: Чувства относительно всего этого";

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: message,
                cancellationToken: cancellationToken,
                replyMarkup: StartDialogKeyboards.TenthLevelKeyboradAudio
            );
        }
        
        else if (update.CallbackQuery.Data == "StartDialog.10Level.Ok")
        {
            var message = "Отлично! Теперь ты точно готов(а) к встрече с феноменом самозванца. " +
                          "\nНо пускай он в не посетит тебя ни завтра, ни сегодня." +
                          "\n\nДо встречи!";

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: message,
                cancellationToken: cancellationToken
            );
        }
        
        else if (update.CallbackQuery.Data == "StartDialog.Bye")
        {
            var message = "До встречи!";

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: message,
                cancellationToken: cancellationToken
            );
        }
    }

 
}
