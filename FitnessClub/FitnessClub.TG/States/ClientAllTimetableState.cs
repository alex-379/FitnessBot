using FitnessClub.BLL;
using FitnessClub.BLL.Models.SportTypeModels;
using FitnessClub.BLL.Models.TimetableModels.OutputModels;
using FitnessClub.TG.Handlers.MessageHandlers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class ClientAllTimetableState : AbstractState
    {
        int i = 0;
        string sportType;
        bool workoutType;
        string date;
        int timetableId;

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (i == 0)
                {
                    sportType = callback;
                }

                if (i == 1)
                {
                    if (callback == "2")
                    {
                        workoutType = false;
                    }

                    if (callback == "1")
                    {
                        workoutType = true;
                    }
                }

                if (i == 2)
                {
                    if (callback == "GetToBeginning")
                    {
                        i = -1;
                    }

                    else
                    {
                        date = callback;
                    }
                }

                if (i == 3)
                {
                    timetableId = Convert.ToInt32(callback);
                }
                i++;
            }

            return this;
        }

        public override void SendMessage(long chatId)
        {
            if (i == 0)
            {
                SportTypeHandler sportTypeHandler = new();
                var sportTypes = sportTypeHandler.GetAllSportTypesNames();
                List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
                int count = 0;

                foreach (SportTypeNameOutputModel s in sportTypes)
                {
                    if (count % 2 == 0)
                    {
                        buttons.Add(new List<InlineKeyboardButton>());
                    }
                    buttons[buttons.Count - 1].Add(new InlineKeyboardButton(s.SportType) { CallbackData = (s.SportType) });
                    count++;
                }

                InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите вид спорта:", replyMarkup: inlineKeyboard);
            }

            if (i == 1)
            {
                var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Групповая", "1"),},
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Индивидуальная", "2"),},
                });
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите тип тренировки:", replyMarkup: inlineKeyboard);
            }

            if (i == 2)
            {
                string text = "Выберите дату:";
                TimetableClient timetableClient = new();
                List<AllTimetablesWithCoachWorkoutsGymsClientsOutputModel> dates = timetableClient.GetAllTimetablesWithCoachWorkoutsGymsClients();
                var filteredResults = from GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel in dates
                                      where GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.SportType.SportType == sportType &
                                      GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Workout.IsGroup == workoutType
                                      select GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel;

                List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
                int count = 0;

                foreach (AllTimetablesWithCoachWorkoutsGymsClientsOutputModel i in filteredResults)
                {
                    if (count % 2 == 0)
                    {
                        buttons.Add(new List<InlineKeyboardButton>());
                    }
                    buttons[buttons.Count - 1].Add(new InlineKeyboardButton(i.Date) { CallbackData = (i.Date) });
                    count++;
                }

                if (buttons.Count == 0)
                {
                    text = "Извините, таких тренировок нет. Выберите другой вид спорта или тип тренировки.";
                    buttons.Add(new List<InlineKeyboardButton>());
                    buttons[buttons.Count - 1].Add(new InlineKeyboardButton("Расписание тренировок")
                    { CallbackData = "GetToBeginning" });
                    count++;
                }
                InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, text, replyMarkup: inlineKeyboard);
            }

            if (i == 3)
            {
                TimetableClient timetableClient = new();
                List<AllTimetablesWithCoachWorkoutsGymsClientsOutputModel> timetables = timetableClient.GetAllTimetablesWithCoachWorkoutsGymsClients();
                var filteredResults = from GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel in timetables
                                      where GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.SportType.SportType == sportType &
                                      GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Date == date &
                                      GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Workout.IsGroup == workoutType
                                      select GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel;

                List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
                int count = 0;

                foreach (AllTimetablesWithCoachWorkoutsGymsClientsOutputModel i in filteredResults)
                {
                    buttons.Add(new List<InlineKeyboardButton>());
                    buttons[buttons.Count - 1].Add(new InlineKeyboardButton($"{i.StartTime} - {i.Workout.Duration} мин., {i.Workout.Price} руб., " +
                        $"тренер {i.Coach.FullName}")
                    { CallbackData = Convert.ToString(i.Id) });
                    count++;
                }

                InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите тренировку:", replyMarkup: inlineKeyboard);
            }
        }
    }
}