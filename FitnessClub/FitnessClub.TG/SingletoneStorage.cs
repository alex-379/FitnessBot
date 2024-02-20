using FitnessClub.TG.States;
using Telegram.Bot;

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
