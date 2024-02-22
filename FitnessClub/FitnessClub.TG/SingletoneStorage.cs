using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessClub.TG.States;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace FitnessClub.TG
{
    public class SingletoneStorage
    {
        private static SingletoneStorage _object = null;

        public ITelegramBotClient Client { get; private set; }

        public Dictionary<long, AbstractState> Clients { get; private set; }

        private SingletoneStorage()
        {
            Client = new TelegramBotClient(Options.token);
            Clients = new Dictionary<long, AbstractState>();
        }

        public static SingletoneStorage GetStorage()
        {
            if (_object is null)
            {
                _object = new SingletoneStorage();
            }
            return _object;
        }
    }
}
