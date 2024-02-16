using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace FitnessClub.TG.States
{
    public class TestState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                return new StartState(update.Message.Chat.FirstName);
            }
            return this;
        }

        public override void SendMessage(long ChatId)
        {
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, $"Еще одно тестовое состояние");
        }
    }
}
