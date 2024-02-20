using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using FitnessClub.BLL;

namespace FitnessClub.TG.States
{
    public class TestState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                return new StartState(update.Message.Chat.FirstName);
            }
            return this;
        }

        public override void SendMessage(long ChatId)
        {
            string text = null;

            TimetableClient timetableClient = new();

            var timetables = timetableClient.GetAllTimetablesWithCoachWorkoutsGymsClients();

            foreach (var i in timetables)
            {
                text = $"Тренировка: {i.SportType.SportType} ({i.Workout.Comment}) - {i.DateTime}, длительность {i.Workout.Duration} час, " +
                    $"цена {i.Workout.Price} рублей, тренер {i.Coach.FullName} в зале номер {i.Gym.Gym}";
            }

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, text);
        }
    }
}
