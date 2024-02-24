using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FitnessClub.TG.States
{
    public class AuthenticationState : AbstractState
    {
        private PersonClient _personClient;

        public AuthenticationState()
        {
            _personClient = new();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message.Text;

                var admins = _personClient.GetAllPersonsOtpByRoleId(1);

                var coaches = _personClient.GetAllPersonsOtpByRoleId(2);

                foreach (EmployeeOutputModelForCheckOnAdminRightesByOTP i in admins)
                {
                    if (update.Message.Text == $"{i.OneTimePassword}")
                    {
                        return new AdministratorState();
                    }
                }

                foreach (EmployeeOutputModelForCheckOnAdminRightesByOTP i in coaches)
                {
                    if (update.Message.Text == $"{i.OneTimePassword}")
                    {
                        return new CoachState();
                    }
                }
            }

            return this;
        }

        public override void SendMessage(long chatId)
        {
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Введите пароль");
        }
    }
}