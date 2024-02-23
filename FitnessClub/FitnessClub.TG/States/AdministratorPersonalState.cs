using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FitnessClub.TG.States
{
    public class AdministratorPersonalState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            throw new NotImplementedException();
        }

        public override void SendMessage(long ChatId)
        {
            throw new NotImplementedException();
        }
    }
}
