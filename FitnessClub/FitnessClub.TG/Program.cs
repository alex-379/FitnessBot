using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace FitnessClub.TG
{
    public class Program
    {
        static void Main(string[] args)
        {
            ITelegramBotClient client = new TelegramBotClient(Options.token);

            var cts = new CancellationTokenSource();

            var cancellationToken = cts.Token;

            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = { }
            };

            client.StartReceiving
                (
                HandleUpdate,
                HandleError,
                receiverOptions,
                cancellationToken
                );

            string quit = "";
            do
                quit = Console.ReadLine();
            while (quit != "quit");
        }

        public static void HandleUpdate(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(update.Message.Text);
        }

        public static void HandleError(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
