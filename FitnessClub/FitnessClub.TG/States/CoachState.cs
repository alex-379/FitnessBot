using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class CoachState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
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
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, $"Добро пожаловать в меню тренера");
        }
    }
}
