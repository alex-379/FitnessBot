using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
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

                if (callbackQuery.Data == "ClientAllTimetableState")
                {
                    return new ClientAllTimetableState();
                }

                if (callbackQuery.Data == "ClientMyTimetableState")
                {
                    return new ClientMyTimetableState();
                }

                return this;
            }

            if (update.Type == UpdateType.Message)
            {

                var message = update.Message.Text.ToLower();

                if (message == "/login")
                {
                    PersonClient personClient = new();

                    var admins = personClient.GetAllPersonsTelegramUserIdByRoleId(1);

                    var coaches = personClient.GetAllPersonsTelegramUserIdByRoleId(2);

                    foreach (EmployeeOutputModelForCheckOnAdminRightesByTuid i in admins)
                    {
                        if (update.Message.Chat.Id == i.TelegramUserId)
                        {
                            return new AdministratorState();
                        }
                    };

                    foreach (EmployeeOutputModelForCheckOnAdminRightesByTuid i in coaches)
                    {
                        if (update.Message.Chat.Id == i.TelegramUserId)
                        {
                            return new CoachState();
                        }
                    };
                }
            }

            return new AuthenticationState();
        }

        public override void SendMessage(long ChatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Посмотреть расписание тренировок", "ClientAllTimetableState"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Посмотреть свои записи", "ClientMyTimetableState"),},
                });

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, $"Здравствуйте {_name}, добро пожаловать в наш фитнес клуб!", replyMarkup: inlineKeyboard);
        }
    }
}