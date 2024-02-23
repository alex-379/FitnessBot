using FitnessClub.TG;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class AdministratorState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            //if (update.Type == UpdateType.Message)
            //{
            //    return this;
            //}
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (callback == "AdministratorPersonalState")
                {
                    return new AdministratorPersonalState();
                }
                if (callback == "AdministratorWorkoutsState")
                {
                    return new AdministratorWorkoutsState();
                }
                if (callback == "AdministratorTimetablesState")
                {
                    return new AdministratorTimetablesState();
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
                    { InlineKeyboardButton.WithCallbackData("Персонал", "AdministratorPersonalState"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Тренировки", "AdministratorWorkoutsState"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Расписание", "AdministratorTimetablesState"),},
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, $"Добро пожаловать в меню администратора", replyMarkup: inlineKeyboard);
        }
    }
}