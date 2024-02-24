using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FitnessClub.TG.States
{
    public class AuthenticationState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message.Text;

                if (message == "123456")
                {
                    return new AdministratorState();
                }
                else
                {
                    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id, $"Ошибка доступа");
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