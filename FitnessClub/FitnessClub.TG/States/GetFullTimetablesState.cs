﻿using FitnessClub.BLL;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FitnessClub.TG.States
{
    public class GetFullTimetablesState : AbstractState
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

            var timetables = timetableClient.GetAllTimetables();

            foreach (var i in timetables)
            {
                text = $"Тренировка номер {i.WorkoutId} {i.Date}, {i.StartTime} тренер {i.CoachId} в зале номер {i.GymId}";
            }

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, text);
        }
    }
}
