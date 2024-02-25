using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.InputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class AdministratorPersonalRegistrationStateByOtp : AbstractState
    {
        private int _password;
        private RegistrationEmployeeByOtpInputModel _personModel;
        private PersonClient _personClient;

        public AdministratorPersonalRegistrationStateByOtp()
        {
            _personModel = new();
            _personClient = new();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (callback == "1")
                {
                    _personModel.RoleId = 1;
                }

                if (callback == "2")
                {
                    _personModel.RoleId = 2;
                }

                _password = _personClient.GetPassword();
                _personModel.OneTimePassword = _password;
                _personClient.AddPersonWithOtp(_personModel);
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id, $"Внесена новая запись. Передайте пароль {_password} сотруднику");
                return new AdministratorState();
            }

            return this;
        }

        public override void SendMessage(long chatId)
        {
            {
                 var inlineKeyboard = new InlineKeyboardMarkup(
                 new List<InlineKeyboardButton[]>()
                    {
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Администратор", "1"),},
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Тренер", "2"),},
                    }
                    );
                    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите роль:", replyMarkup: inlineKeyboard);
            }
        }
    }
}