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
        private string _name;
        private PersonClient _personClient;

        public StartState(string name)
        {
            this._name = name;
            _personClient = new();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callbackQuery = update.CallbackQuery;

                if (callbackQuery.Data == "ClientAllTimetableState")
                {
                    return new ClientRegistrationState();
                }

                if (callbackQuery.Data == "ClientMyTimetableState")
                {
                    return new ClientMyTimetableState();
                }
            }

            if (update.Type == UpdateType.Message)
            {

                var message = update.Message.Text.ToLower();

                if (message == "/login")
                {
                    var admins = _personClient.GetAllPersonsTelegramUserIdByRoleId(1);

                    var coaches = _personClient.GetAllPersonsTelegramUserIdByRoleId(2);

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

        public override void SendMessage(long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Посмотреть расписание тренировок", "Registration"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Посмотреть свои записи", "ClientMyTimetableState"),},
                });

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Здравствуйте {_name}, добро пожаловать в наш фитнес клуб!", replyMarkup: inlineKeyboard);
        }
    }
}