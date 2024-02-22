using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class StartState : AbstractState
    {
        public string _name;
        public StartState(string name)
        {
            this._name = name;
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callbackQuery = update.CallbackQuery;
                if (callbackQuery.Data == "GetFullTimetablesState")
                {
                    //SingletoneStorage.GetStorage().Client.AnswerCallbackQueryAsync(callbackQuery.Id);
                    return new GetFullTimetablesState();
                }

                if (callbackQuery.Data == "Back")
                {
                    SingletoneStorage.GetStorage().Client.AnswerCallbackQueryAsync(callbackQuery.Id);
                    return new StartState(callbackQuery.From.FirstName);
                }
            }
            return this;
        }

        public override void SendMessage(long ChatId)
        {

            var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Зарегистрироваться", "1"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Посмотреть расписание тренировок", "GetFullTimetablesState"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Еще", "2"),
                      InlineKeyboardButton.WithCallbackData("Еще", "3"),
                      InlineKeyboardButton.WithCallbackData("Еще", "4")},
                });

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, $"Здравствуйте {_name}, добро пожаловать в наш фитнес клуб", replyMarkup: inlineKeyboard);
        }
    }
}
