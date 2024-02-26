using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using FitnessClub.BLL.Models.TimetableModels.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class CoachTimetableState : AbstractState
    {
        int i = 0;
        int coachId;
        int timetableId;

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (i == 0)
                {
                    timetableId = Convert.ToInt32(callback);
                }

                if (i == 1)
                {

                }
                i++;
            }

            return this;
        }

        public override void SendMessage(long chatId)
        {
            if (i == 0)
            {
                PersonClient personClient = new();
                List<PersonWithTgIdOutputModel> coachWithTgIds = personClient.GetPersonsWithTgIdByRoleId(2);
                var filteredCoaches = from CoachWithTgId in coachWithTgIds
                                      where CoachWithTgId.TelegramUserId == chatId
                                      select CoachWithTgId;
                foreach (var i in filteredCoaches)
                {
                    coachId = i.Id;
                }

                TimetableClient timetableClient = new();
                List<AllTimetablesWithCoachWorkoutsGymsClientsOutputModel> timetablesCoach = timetableClient.GetAllTimetablesWithCoachWorkoutsGymsClients();
                var filteredTimetables = from GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel in timetablesCoach
                                         where GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Coach.Id == coachId
                                         select GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel;

                List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
                int count = 0;

                foreach (AllTimetablesWithCoachWorkoutsGymsClientsOutputModel i in filteredTimetables)
                {
                    buttons.Add(new List<InlineKeyboardButton>());
                    buttons[buttons.Count - 1].Add(new InlineKeyboardButton($"{i.Date} - {i.StartTime} {i.Workout.Comment}")
                    { CallbackData = Convert.ToString(i.Id) });
                    count++;
                }

                InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите тренировку:", replyMarkup: inlineKeyboard);
            }

            if (i == 1)
            {
                string text = null;
                TimetableClient timetableClient = new();
                List<AllTimetablesWithCoachWorkoutsGymsClientsOutputModel> timetablesCoach = timetableClient.GetAllTimetablesWithCoachWorkoutsGymsClients();
                var filteredTimetables = from GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel in timetablesCoach
                                         where GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Coach.Id == coachId &
                                         GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Id == timetableId
                                         select GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel;

                List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
                int count = 0;

                foreach (AllTimetablesWithCoachWorkoutsGymsClientsOutputModel i in filteredTimetables)
                {
                    text = $"{i.Date} в {i.StartTime}, {i.Workout.Comment}, продолжительность {i.Workout.Duration} минут, " +
                        $"стоимость {i.Workout.Price} руб. с человека в {i.Gym.Gym}. Список клиентов:";
                    //List<ClientForTimetableOutputModel> clients = i.Client.Id;
                    foreach (AllTimetablesWithCoachWorkoutsGymsClientsOutputModel a in filteredTimetables)
                    {
                        if (count % 2 == 0)
                        {
                            buttons.Add(new List<InlineKeyboardButton>());
                        }
                        buttons[buttons.Count - 1].Add(new InlineKeyboardButton(a.Client.FullName) { CallbackData = Convert.ToString(a.Client.Id) });
                        count++;
                    }

                }
                InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, text, replyMarkup: inlineKeyboard); ;
            }
        }
    }
}