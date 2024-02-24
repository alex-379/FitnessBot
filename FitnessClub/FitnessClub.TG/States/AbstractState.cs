using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FitnessClub.TG.States
{
    public abstract class AbstractState
    {
        public abstract void SendMessage(long chatId);

        public abstract AbstractState ReceiveMessage(Update update);

        public AbstractState ReceiveMenu(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message.Text.ToLower();
                if (message == "/start")
                {
                    return new StartState(update.Message.Chat.FirstName);
                }
            }

            return this;
        }
    }
}