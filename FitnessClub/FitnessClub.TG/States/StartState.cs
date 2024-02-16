using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FitnessClub.TG.States
{
    public class StartState : AbstractState
    {
        public string name;
        public StartState(string name)
        {
            this.name = name;
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message.Text.ToLower();
                if (message == "a")
                {
                    return new GetAllTimetablesState();
                }
                else if (message == "b")
                {
                    return new TestState();
                }
            }
            return this;
        }

        public override void SendMessage(long ChatId)
        {
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, $"Здравствуйте {name}, выберите a или b");
        }
    }
}
