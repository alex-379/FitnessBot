using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG
{
    public class Program
    {
        static List<long> chats = new();

        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            var cancellationToken = cts.Token;

            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery],
            };

            Options.client.StartReceiving
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
            if (update.Type == UpdateType.Message)
            {
                if (update.Message.Text == "/start")
                {
                    chats.Add(update.Message.Chat.Id);
                }

                Console.WriteLine($"{update.Message.Chat.Id} {update.Message.Chat.FirstName} {update.Message.Chat.LastName} {update.Message.Text}");

                foreach (var i in chats)
                {
                    if (i != update.Message.Chat.Id)
                    {
                        client.SendTextMessageAsync(i, $"Ваши данные: {update.Message.Chat.FirstName} {update.Message.Chat.LastName} Вы написали {update.Message.Text}");
                    }
                }

                InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                    new InlineKeyboardButton[][]
                    {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Button1") { CallbackData="1"},
                            new InlineKeyboardButton("Button2") { CallbackData="2"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Button3") { CallbackData="3"},
                        },
                    }
                    );

                client.SendTextMessageAsync(update.Message.Chat.Id, $"Ваши данные: {update.Message.Chat.FirstName} {update.Message.Chat.LastName}. Вы запросили {update.Message.Text}. Сделайте выбор", replyMarkup: markup);
            }

            else if (update.Type == UpdateType.CallbackQuery)
            {
                Console.WriteLine(update.CallbackQuery.Data);
            }
        }

        public static void HandleError(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
