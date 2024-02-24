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
                ThrowPendingUpdates = true
            };

            client.StartReceiving(HandleUpdate, HandleError, receiverOptions, cancellationToken);
            string quit = "";
            do
                quit = Console.ReadLine();
            while (quit != quit);
        }

        public static void HandleUpdate(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            var clients = SingletoneStorage.GetStorage().Clients;
            long id = update.Message != null ?
                update.Message.Chat.Id
                : update.CallbackQuery.From.Id;

            if (update.Message != null && !clients.ContainsKey(id))
            {
                clients.Add(id, new StartState(update.Message.Chat.FirstName));
            }
            else if (update.Message == null && !clients.ContainsKey(id))
            {
                clients.Add(id, new StartState(update.CallbackQuery.From.FirstName));
            }
            else
            {
                var tmp = clients[id].ReceiveMenu(update);
                if (tmp == clients[id])
                {
                    clients[id] = clients[id].ReceiveMessage(update);
                }
                else
                {
                    clients[id] = tmp;
                }
            }
            clients[id].SendMessage(id);
        }

        public static void HandleError(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}