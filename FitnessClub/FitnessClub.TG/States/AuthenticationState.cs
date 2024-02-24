using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using FitnessClub.TG.Handlers.MessageHandlers;

namespace FitnessClub.TG.States
{
    public class AuthenticationState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message.Text;

                PersonHandler personHandler = new ();

                var admins = personHandler.GetAllPersonsOtpByRoleId(1);

                var coaches = personHandler.GetAllPersonsOtpByRoleId(2);

                foreach (EmployeeModelForCheckOnAdminRightesByOtp i in admins)
                {
                    if (update.Message.Text == $"{i.OneTimePassword}")
                    {
                        return new AdministratorState();
                    }
                }

                foreach (EmployeeModelForCheckOnAdminRightesByOtp i in coaches)
                {
                    if (update.Message.Chat.Id == i.OneTimePassword)
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