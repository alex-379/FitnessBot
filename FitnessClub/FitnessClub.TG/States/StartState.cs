using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class StartState : AbstractState
    {
        public string _name;
        public StartState(string name)
        {
            this._name = name;
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callbackQuery = update.CallbackQuery;

                if (callbackQuery.Data == "GetFullTimetablesState")
                {
                    //SingletoneStorage.GetStorage().Client.AnswerCallbackQueryAsync(callbackQuery.Id);
                    return new GetFullTimetablesState();
                }

                if (callbackQuery.Data == "Back")
                {
                    //SingletoneStorage.GetStorage().Client.AnswerCallbackQueryAsync(callbackQuery.Id);
                    return new StartState(callbackQuery.From.FirstName);
                }
            }

            if (update.Type == UpdateType.Message)
            {

                var message = update.Message.Text.ToLower();

                if (message == "/login")
                {
                    PersonClient personClient = new();

                    var admins = personClient.GetAllPersonsByRoleId(1);

                    var coaches = personClient.GetAllPersonsByRoleId(2);

                    List <long> TelegramUserId = new();

                    foreach (EmployeeModelForCheckOnAdminRightes i in admins)
                        {
                        TelegramUserId.Add(i.TelegramUserId);
                    };

                    List<long> TelegramUserId2 = new();

                    foreach (EmployeeModelForCheckOnAdminRightes i in coaches)
                    {
                        TelegramUserId2.Add(i.TelegramUserId);
                    };

                    if (TelegramUserId.Contains(update.Message.Chat.Id))
                    {
                        return new AdministratorState();
                    }

                    else if (TelegramUserId2.Contains(update.Message.Chat.Id))
                    {
                        return new CoachState();
                    }

                    else
                    {
                        return new StartState(update.Message.Chat.FirstName);
                    }
                    //Console.WriteLine();
                    ////long id = update.Message.Chat.Id

                    ////if (admins.)
                    //return new RegistrationState();
                }
            }

            return this;
        }

        public override void SendMessage(long ChatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Посмотреть расписание тренировок", "GetFullTimetablesState"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Посмотреть свои записи", "1"),},
                });

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, $"Здравствуйте {_name}, добро пожаловать в наш фитнес клуб!", replyMarkup: inlineKeyboard);
        }
    }
}
