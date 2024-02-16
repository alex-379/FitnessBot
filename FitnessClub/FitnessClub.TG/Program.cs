using FitnessClub.TG.States;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

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

            Options.client.StartReceiving(HandleUpdate, HandleError, receiverOptions, cancellationToken);
            string quit = "";
            do
                quit = Console.ReadLine();
            while (quit != quit);
        }

        public static void HandleUpdate(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
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
                clients[id]=clients[id].ReceiveMessage(update);
                clients[id].SendMessage(id);
            }
        }
            //        InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
            //            new InlineKeyboardButton[][]
            //            {
            //                new InlineKeyboardButton[]
            //                {
            //                    new InlineKeyboardButton("Button1") { CallbackData="1"},
            //                    new InlineKeyboardButton("Button2") { CallbackData="2"},
            //                },
            //                new InlineKeyboardButton[]
            //                {
            //                    new InlineKeyboardButton("Button3") { CallbackData="3"},
            //                },
            //            }
            //            );

            //        client.SendTextMessageAsync(update.Message.Chat.Id, $"Ваши данные: {update.Message.Chat.FirstName} {update.Message.Chat.LastName}. Вы запросили {update.Message.Text}. Сделайте выбор", replyMarkup: markup);
            //    }

            //    else if (update.Type == UpdateType.CallbackQuery)
            //    {
            //        Console.WriteLine(update.CallbackQuery.Data);
            //    }
        

        public static void HandleError(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
