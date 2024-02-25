using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.InputModels;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using FitnessClub.BLL.Models.SportTypeModels;
using FitnessClub.BLL.Models.TimetableModels.InputModels;
using FitnessClub.BLL.Models.TimetableModels.OutputModels;
using FitnessClub.TG.Models.TimetableModels.InputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class ClientAllTimetableState : AbstractState
    {
        private int i = 0;
        private int count = 0;
        private SportTypeClient _sportTypeClient;
        private ClientAllTimetableInputModel _timetable;

        public ClientAllTimetableState()
        {
            _sportTypeClient = new();
            _timetable = new();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (i == 0)
                {
                    if (callback == "Registration")
                    {
                        return new ClientRegistrationState();
                    }

                    else
                    {
                        _timetable.SportType = callback;
                    }
                }

                if (i == 1)
                {
                    if (callback == "2")
                    {
                        _timetable.WorkoutType = false;
                    }

                    if (callback == "1")
                    {
                        _timetable.WorkoutType = true;
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
                        _timetable.Date = callback;
                    }
                }

                if (i == 3)
                {
                    _timetable.TimetableId = Convert.ToInt32(callback);
                }

                if (i == 4)
                {
                    if (callback == "ClientMyTimetableState")
                    {
                        return new ClientMyTimetableState();
                    }

                    if (callback == "ClientAllTimetableState")
                    {
                        return new ClientAllTimetableState();
                    }
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
                List<ClientAndAdministratorOutputModel> persons = personClient.GetAllPersons();

                foreach (var a in persons)
                {
                    if (a.TelegramUserId == chatId)
                    {
                        _timetable.TelegramUserId = (long)a.TelegramUserId;
                        _timetable.ClientId = a.Id;
                    }
                }

                if (_timetable.TelegramUserId == chatId)
                {
                    var sportTypes = _sportTypeClient.GetAllSportTypesNames();
                    List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();

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

                else
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Пожалуйста, зарегистрируйтесь.", "Registration"),},
                });
                    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, " ", replyMarkup: inlineKeyboard);
                }
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
                                      where GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.SportType.SportType == _timetable.SportType &
                                      GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Workout.IsGroup == _timetable.WorkoutType
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
                                      where GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.SportType.SportType == _timetable.SportType &
                                      GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Date == _timetable.Date &
                                      GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Workout.IsGroup == _timetable.WorkoutType
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

            if (i == 4)
            {
                ClientTimetableInputModel clientTimetable = new ClientTimetableInputModel
                {
                    СlientId = (int)_timetable.ClientId,
                    TimetableId = (int)_timetable.TimetableId
                };
                TimetableClient timetableClient = new();
                timetableClient.AddClientTimetable(clientTimetable);

                var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Посмотреть мои записи", "ClientMyTimetableState"),},
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Записаться на другие тренировки", "ClientAllTimetableState"),},
                });
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Вы успешно записались на тренировку!", replyMarkup: inlineKeyboard);
            }
        }
    }
}