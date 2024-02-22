using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class GetAllTimetablesState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callbackQuery = update.CallbackQuery;
                var user = callbackQuery.From;

                Console.WriteLine($"{user.FirstName} ({user.Id}) нажал на кнопку: {callbackQuery.Data}");

                if (callbackQuery.Data == "GetFullTimetablesState")
                {
                    //SingletoneStorage.GetStorage().Client.AnswerCallbackQueryAsync(callbackQuery.Id);
                    return new GetFullTimetablesState();
                }

                if (callbackQuery.Data == "Back")
                {
                    SingletoneStorage.GetStorage().Client.AnswerCallbackQueryAsync(callbackQuery.Id);
                    return new StartState(update.Message.Chat.FirstName);
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
                    { InlineKeyboardButton.WithCallbackData("Расписание тренировок", "GetFullTimetablesState"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Список тренеров", "Coaches"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Назад", "Back"),},
                });

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, $"Здравствуйте, добро пожаловать в наш фитнес клуб!", replyMarkup: inlineKeyboard);
        }
    }
}
