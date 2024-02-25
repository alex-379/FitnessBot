using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using FitnessClub.BLL.Models.TimetableModels.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class ClientMyTimetableState : AbstractState
    {
        int i = 0;
        int clientId;
        int timetableId;

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
                        timetableId = Convert.ToInt32(callback);
                    }
                }

                if (i == 1)
                {
                    if (callback == "GetToBeginning")
                    {
                        i = -1;
                    }

                    else
                    {

                    }
                }
                i++;
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            long crntTelegramUserId = 1;

            if (i == 0)
            {
                PersonClient personClient = new();
                List<ClientAndAdministratorOutputModel> persons = personClient.GetAllPersons();

                foreach (var a in persons)
                {
                    if (a.TelegramUserId == chatId)
                    {
                        crntTelegramUserId = (long)a.TelegramUserId;
                    }
                }

                if (crntTelegramUserId == chatId)
                {
                    List<CoachWithTgId> clientWithTgIds = personClient.GetCoachesWithTgIdByRoleId(3);
                    var filteredClients = from CoachWithTgId in clientWithTgIds
                                          where CoachWithTgId.TelegramUserId == chatId
                                          select CoachWithTgId;

                    foreach (var i in filteredClients)
                    {
                        clientId = i.Id;
                    }

                    TimetableClient timetableClient = new();
                    List<AllTimetablesWithCoachWorkoutsGymsClientsOutputModel> timetablesClient = timetableClient.GetAllTimetablesWithCoachWorkoutsGymsClients();
                    var filteredTimetables = from GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel in timetablesClient
                                             where GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Client.Id == clientId
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
                    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Ваши тренировки:", replyMarkup: inlineKeyboard);
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
                string text = null;
                TimetableClient timetableClient = new();
                List<AllTimetablesWithCoachWorkoutsGymsClientsOutputModel> timetablesClient = timetableClient.GetAllTimetablesWithCoachWorkoutsGymsClients();
                var filteredTimetables = from GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel in timetablesClient
                                         where GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Client.Id == clientId &
                                         GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Id == timetableId
                                         select GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel;

                foreach (AllTimetablesWithCoachWorkoutsGymsClientsOutputModel i in filteredTimetables)
                {
                    text = $"{i.Date} в {i.StartTime}, {i.Workout.Comment}, продолжительность {i.Workout.Duration} минут, " +
                        $"стоимость {i.Workout.Price} руб. в {i.Gym.Gym}, тренер {i.Coach.FullName}.";
                }

                List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
                int count = 0;

                buttons.Add(new List<InlineKeyboardButton>());
                buttons[buttons.Count - 1].Add(new InlineKeyboardButton("Отменить тренировку")
                { CallbackData = Convert.ToString(timetableId) });
                buttons.Add(new List<InlineKeyboardButton>());
                buttons[buttons.Count - 1].Add(new InlineKeyboardButton("Посмотреть остальные тренировки")
                { CallbackData = "GetToBeginning" });
                count++;

                InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, text, replyMarkup: inlineKeyboard);
            }
        }
    }
}