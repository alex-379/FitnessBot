using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FitnessClub.TG.States
{
    public abstract class AbstractState
    {
        public abstract void SendMessage(long ChatId);

        public abstract AbstractState ReceiveMessage(Update update);

        //public AbstractState ReceiveMenu(Update update)
        //{
        //    if (update.Type == UpdateType.Message)
        //    {
        //        var message = update.Message;
        //        if (message == "/start") 
        //        {
        //            return new StartState;
        //        }
        //    }

        //    return this;
        
    }
}