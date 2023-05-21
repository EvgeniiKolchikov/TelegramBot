using ImpostorHelp.Telegram.Handlers;
using ImpostorHelp.Telegram.Keyboards;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImpostorHelp.Telegram.Dialogs;

/// <summary>
/// негативный сценарий ежедневного диалога
/// </summary>
public class DailyNegativeDialog
{

    private UserNegativeChoiceRecordHandler _choiceRecordHandler;
    private SupportHandler _supportHandler;

    public DailyNegativeDialog()
    {
        _choiceRecordHandler = new UserNegativeChoiceRecordHandler();
        _supportHandler = new SupportHandler();
    }
    public async Task DailyNegativeCallBackQueryDialog(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.CallbackQuery != null && update.CallbackQuery.Data != null)
        {
            var chatId = update.CallbackQuery.From.Id;

            if (update.CallbackQuery.Data == "DailyNegativeDialog.1Level")
            {
                var level1Message =
                    "Оцени степень недовольства собой по шкале от 1 до 10 (где 1 - это легкие сомнения, а 10 - ощущение себя полным ничтожеством)";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level1Message,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogKeyboards.SecondLevelKeyboard
                );
            }
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.2Level.1-3"))
            {
                await _choiceRecordHandler.SaveFirstChoiceAsync(chatId, update.CallbackQuery.Data);
                var level2Message13 = "Давай разберём ситуацию, и посмотрим, как ты можешь поддержать себя";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level2Message13,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogAnalysisKeyboards.ThirdLevelKeyboard13
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.3Level.1-3"))
            {
                var level4Message13 = "Опиши ситуацию, в которой ты почувствовал себя самозванцем, используя только факты. " +
                                      "Кто участвовал в ситуации? Когда это произошло? Где? Что конкретно делал ты? " +
                                      "А какие действия совершали другие важные участники этого события?";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level4Message13,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogAnalysisKeyboards.FourLevelKeyboard13
                );
            }
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.4Level.1-3"))
            {
                var level5Message13 = "Начнём с лёгкого самоанализа. " +
                                      "Так бывает, что человек, в эмоциональных ситуациях вместо описания фактов использует оценки и образы которые мешают воспринимать ситуацию трезво. " +
                                      "\nНапример, сравни фразы: \n1) \"начальник прислал правки к моему проекту\" (это - факт)" +
                                      "\n2) \"начальник как обычно разнёс мой проект  в пух и прах\" (это - оценка)" +
                                      "\n \nПеречитай своё описание ситуации. Если нужно, скопируй текст и переформулируй оценки на факты. У тебя получится! :)";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level5Message13,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogAnalysisKeyboards.FiveLevelKeyboard13
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.5Level.1-3.Facts"))
            {
                var level5Message13 = "Супер! Здорово, что ты уже умеешь отделять факты от оценок. " +
                                      "Это важный навык психологической гигиены! " +
                                      "Тогда переходим к следующему этапу. Опиши чувства, которые возникали в этой ситуации. " +
                                      "Например, \"когда я получил письмо от начальника, я испугался\" или \"когда я увидел правки, мне стало стыдно\"";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level5Message13,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogAnalysisKeyboards.SixLevelKeyboard13
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.5Level.1-3.Fix"))
            {
                var message = "Отлично! Ты потренировался отделять факты от оценок! " +
                              "Теперь переходим к следующему этапу. Опиши чувства, которые возникали в этой ситуации. " +
                              "Например, \"когда я получил письмо от начальника, я испугался\" или " +
                              "\"когда я увидел правки, я разозлился\"";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogAnalysisKeyboards.SixLevelKeyboard13
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.6Level.1-3"))
            {
                var message =
                    "Очень часто нам доставляют страдания не столько сами события, сколько наше видение ситуации. " +
                    "Сравни: \"когда я увидел правки, я подумал \"если бы я хорошо работал, то правок бы не было\" и мне стало стыдно\" " +
                    "или \"когда я увидел правки, я подумал \"начальник всё время ко мне придирается\" и разозлился\". " +
                    "\nВидишь: эмоции зависят от того, как человек интерпретирует ситуацию." +
                    "\n \nТеперь скопируй предыдущий текст и добавь к каждой эмоции мысли, которые её вызвали.";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogAnalysisKeyboards.SevenLevelKeyboard13
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.7Level.1-3"))
            {
                var message = "Супер! Круто, что тебе хватило терпения дойти до этого шага самопомощи. Впереди самое вкусное!" +
                              "Как ты видишь, одну и ту же ситуацию можно понимать очень разными способами. " +
                              "На старте ты описал видение ситуации, которое пришло тебе в первую очередь. " +
                              "Как бы ты ещё мог объяснить произошедшее?" +
                              "\n \nНапример: не только \"если бы я хорошо работал, то правок бы не было\", " +
                              "он и \"я допускал глупые ошибки в прошлом проекте, и теперь начальник относится ко мне более критично\"." +
                              "\n \nТеперь напиши ещё 1-2 гипотезы, которые объясняют то, что с тобой сегодня произошло.";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogAnalysisKeyboards.EightLevelKeyboard13
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.8Level.1-3"))
            {
                var message = "Наверняка, для тебя уже привычен взгляд на себя глазами \"самозванца\". " +
                              "Поэтому первые объяснения, которые приходят тебе в голову, подтверждают идею самозванчества. " +
                              "Но, как ты уже знаешь, одну и ту же ситуацию можно видеть совершенно по-разному." +
                              "И сейчас я попрошу тебя посмотреть на произошедшее глазами человека, у которого нет \"синдрома самозванца\". " +
                              "\nЭтот человек - оптимист: обычно он видит причины сложностей не в том, что с ним по жизни что-то не так, " +
                              "а в том, что были какие-то конкретные, в том числе внешние, факторы, которые повиляли на ситуацию. " +
                              "\nНапример: \"начальник прислал много правок, потому что он очень тревожится за этот проект и хочет сделать всё идеально\" " +
                              "или \"начальник прислал много правок, потому что я доделывал этот проект, " +
                              "когда плохо себя чувствовал, и не заметил некоторые ошибки.\"" +
                              "\n \nПопробуй сейчас написать 3-4 объяснения твоей ситуации, которые предложил бы оптимист.";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogAnalysisKeyboards.NineLevelKeyboard13
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.9Level.1-3"))
            {

                var message = "Отлично! Теперь ты можешь увидеть произошедшее с разных сторон и понять: " +
                              "дело не в том, что ты самозванец, просто с тобой случилась неприятная ситуация. " +
                              "Одна конкретная ситуация, которую можно объяснить множеством разных причин :)" +
                              "\n \nОцени ещё раз, насколько ты чувствуешь себя самозванцем теперь? " +
                              "(где 1 - это легкие сомнения, а 10 - ощущение себя полным ничтожеством)";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogAnalysisKeyboards.TenLevelKeyboard13
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.10Level"))
            {
                await _choiceRecordHandler.SaveSecondChoiceAsync(chatId, update.CallbackQuery.Data);
                if (!_choiceRecordHandler.SecondMoreThanFirst(chatId))
                {
                    var message = "Поздравляю! " +
                                  "Сегодня ты одержал победу над негативными мыслями и посмотрел на себя более доброжелательным взглядом." +
                                  "\nТы на славу потрудился! До завтра!";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: message,
                        cancellationToken: cancellationToken
                    );
                }
                else
                {
                    var message = "Похоже, что-то пошло не так, и анализ ситуации не улучшил твоё состояние. " +
                                  "Может быть, я могу помочь тебе как-то ещё?";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: message,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyNegativeDialogAnalysisKeyboards.ElevenLevelKeyboard13
                    );
                }
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.2Level.4-7"))
            {
                await _choiceRecordHandler.SaveFirstChoiceAsync(chatId, update.CallbackQuery.Data);
                var level2Message47 =
                    "Ты хочешь разобрать ситуацию или получить поддержку?";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level2Message47,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogKeyboards.ThirdLevelKeyboard47
                );
            }
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.2Level.8-10"))
            {
                var message =
                    " Люди, подверженные Синдрому самозванца, часто склонны преувеличивать ужас неудач." +
                    "\n Дай себе минутку на размышление: может быть ты переоцениваешь своё состояние? 😉 " +
                    "\n Итак, сегодня ты страдал от синдрома самозванца на...";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogKeyboards.SecondLevelKeyboardAfter810
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.Yes.SupportMe"))
            {
                var message =
                    " Хочу напомнить тебе историю, когда ты чувствовал себя умницей.";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: cancellationToken
                );

                var rnd = new Random();
                var number = rnd.Next(1, 5);
                switch (number)
                {
                    case 1: await _supportHandler.GetImageSupport(botClient, update, cancellationToken);
                        break;
                    case 2: await _supportHandler.GetTextSupport(botClient, update, cancellationToken);
                        break;
                    case 3: await _supportHandler.GetVoiceSupport(botClient, update, cancellationToken);
                        break;
                    case 4:
                        await _supportHandler.GetSupportFactsText(botClient, update, cancellationToken);
                        break;
                }

                var message1 =
                    "Оцени, насколько ты чувствуешь себя самозванцем теперь?  (где 1 - это легкие сомнения, а 10 - ощущение себя полным ничтожеством)";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message1,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogKeyboards.KeyboardAfterSupportMe
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.AfterSupport"))
            {
                await _choiceRecordHandler.SaveSecondChoiceAsync(chatId, update.CallbackQuery.Data);
                var m1 = _choiceRecordHandler.GetFirstChoice(botClient, update, cancellationToken);
                var m2 = _choiceRecordHandler.GetSecondChoice(botClient, update, cancellationToken);

                if (m1 == null || m2 == null)
                {
                    
                }
                else if (m1 > m2)
                {
                    var message = "Ух ты, круто! Похоже, что тебе сейчас стало легче.  " +
                                  $"Ведь в начале ты чувствовал себя самозванцем на {m1} баллов, " +
                        $"а теперь интенсивность снизилась до {m2}. " +
                        "Для этого я (бот) и был создан :) " +
                        "Постарайся зафиксировать это ощущение: ты можешь поддерживать себя," +
                        " когда нападает \"синдром самозванца\". Он не всесилен. " +
                        "А ты - да :) Как думаешь, мы можем остановиться на этом? " +
                        "И ты сможешь побыть с ощущением победителя, сохранить это чувство до завтра.";
                    
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: message,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyNegativeDialogKeyboards.KeyboardM1MoreM2
                    );
                }
                else if (m1 == m2)
                {
                    var message = "Я вижу, что твоё состояние осталось прежним. " +
                                  $"Ты всё ещё чувствуешь себя самозванцем на {m1} баллов. " +
                                  $"\nНо может быть за время время нашего разговора ты ощутил, " +
                                  "что можешь справиться с этой ситуацией? Ведь неприятности иногда случаются... " +
                                  "\nСпособность выдерживать огорчения - тоже сильная сторона личности. " +
                                  "Мы можем закончить на этом. Или предложить тебе ещё поддержку?";
                    
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: message,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyNegativeDialogKeyboards.KeyboardM1EqualM2
                    );
                    
                }
                else if (m2 > m1)
                {
                    var message =
                        $"Ох, похоже тебе стало хуже, ведь в начале нашего разговора ты чувствовал себя самозванцем на \"{m1}\", " +
                        $"а теперь на \"{m2}\" баллов. Может быть я могу предложить тебе ещё помощь?";
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: message,
                        cancellationToken: cancellationToken,
                        replyMarkup: DailyNegativeDialogKeyboards.KeyboardM2MoreM1
                    );
                }
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.3Level.8-10"))
            {
                await _choiceRecordHandler.SaveFirstChoiceAsync(chatId, update.CallbackQuery.Data);
                var level3Message810 =
                    " Блин! Очень Жаль... Что может помочь тебе сейчас лучше всего?";
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: level3Message810,
                    cancellationToken: cancellationToken,
                    replyMarkup: DailyNegativeDialogKeyboards.ThirdLevelKeyboard810
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.SelfHelp"))
            {
                var message =
                    " Возможно сейчас я не в силах помочь тебе так, как это необходимо. Но я уверен, что ты можешь обратиться к другим своим ресурсам. " +
                    "\n \nДо завтра!";
                var message1 =
                    "Я опросил опытных психологов (и Интернет). Вот что они рекомендуют для эмоциональной самоподдержки:" +
                    "\n \n1) Ты можешь поделиться своей ситуацией с кем-то близким. На самом деле, феномен самозванца случается со многими людьми. Наверняка, среди твоих знакомых найдётся тот, кто поймёт тебя." +
                    "\n2) Попроси того, кому ты доверяешь, дать тебе обратную связь — перечислить то, что у тебя получается делать хорошо. Только не в общих чертах, а с фактами, примерами — чтобы это могло убедить тебя :)" +
                    "\n3) Переключись с ситуации, которая тебя заботит на то, что точно доставляет тебе удовольствие и получается на ура. Это может быть что угодно: бег, вышивание, готовка ужина, прогулка, настольный игры и т.д." +
                    "\n4) Попробуй психологическую медитацию. Это не заумная практика для опытных йогов, а простое упражнение, которое позволит успокоить дыхание и мысли. В интернете легко найти такие видео (например, вот одно из них: https://www.youtube.com/watch?v=xMSsSr886To)." +
                    "\n5) Подойдут любые формы творчества: нарисовать комикс о сложившейся ситуации, стих, потанцевать под любимую музыку, сделать что-то руками (даже если это просто поделка из мятой бумаги). Кстати, 73% пользователей соц.сетей отмечают, что им становится эмоционально легче, после того, как они опубликуют пост о своей проблеме. Вспомни хоть Степана Савельева и его динозавров :)";
                
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: cancellationToken
                );
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message1,
                    cancellationToken: cancellationToken
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.Psychologist"))
            {
                var message = "Я могу порекомендовать тебе этих специалистов, я проверил их образование и опыт работы. " +
                              "\nВерю, что они могут тебе помочь, а мы с тобой увидимся завтра! " +
                              "\nДо встречи!" +
                              "\nhttps://psyconsult24.ru/psychologists/";
                    
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: cancellationToken
                );
            }
            
            else if (update.CallbackQuery.Data.Contains("DailyNegativeDialog.Exit"))
            {
                var message = "Хорошего тебе нового дня! До встречи!";
                    
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: cancellationToken
                );
            }
        }
    }
}