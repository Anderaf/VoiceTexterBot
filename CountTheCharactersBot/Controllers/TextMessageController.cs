using CountTheCharactersBot.Extensions;
using CountTheCharactersBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CountTheCharactersBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IStorage _memoryStorage;
        public TextMessageController(ITelegramBotClient telegramClient, IStorage memoryStorage)
        {
            _telegramClient = telegramClient;
            _memoryStorage = memoryStorage;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":

                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Подсчёт символов" , $"text"),
                        InlineKeyboardButton.WithCallbackData($" Сумма чисел" , $"math")
                    });

                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Посчитайте кол-во символов или сумму чисел.</b>", 
                        cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                default:
                    var session = _memoryStorage.GetSession(message.Chat.Id);
                    string result = "";
                    switch (session.ModeCode)
                    {
                        case "text":
                            result = StringExtension.GetStringLengthText(message.Text);
                            break;
                        case "math":
                            result = StringExtension.GetSumText(message.Text);
                            break;
                        default:
                            result = "Что-то пошло не так";
                            break;
                    }
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, result, cancellationToken: ct);
                    break;
            }
        }
    }
}
