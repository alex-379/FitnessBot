using FitnessClub.TG.States;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FitnessClub.TG
{
    public class Program
    {
        private SingletoneStorage _storage;

        static List<long> chats = new();

        static void Main(string[] args)
        {
            ITelegramBotClient client = SingletoneStorage.GetStorage().Client;

            var cts = new CancellationTokenSource();

            var cancellationToken = cts.Token;

            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery],
            };

            client.StartReceiving(HandleUpdate, HandleError, receiverOptions, cancellationToken);
            string quit = "";
            do
                quit = Console.ReadLine();
            while (quit != quit);
        }

        public static void HandleUpdate(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {

            if (update.Type == UpdateType.Message)

            {

                var clients = SingletoneStorage.GetStorage().Clients;

                long id = update.Message.Chat.Id;



                if (!clients.ContainsKey(id))

                {

                    clients.Add(id, new StartState(update.Message.Chat.FirstName));

                    clients[id].SendMessage(id);

                }

                else

                {

                    clients[id] = clients[id].ReceiveMessage(update);

                    clients[id].SendMessage(id);

                }

            }

            else if (update.Type == UpdateType.CallbackQuery)

            {

                var clients = SingletoneStorage.GetStorage().Clients;

                long id = update.CallbackQuery.From.Id;

                clients[id] = clients[id].ReceiveMessage(update);

                clients[id].SendMessage(id);

            }

        }



        public static void HandleError(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
