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

                if (callbackQuery.Data == "ClientTimetableState")
                {
                    return new ClientTimetableState();
                }

                if (callbackQuery.Data == "Back")
                {
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

                    List <long> adminTelegramUserId = new();

                    foreach (EmployeeModelForCheckOnAdminRightesByTUID i in admins)
                        {
                        adminTelegramUserId.Add(i.TelegramUserId);
                    };

                    List<long> coachTelegramUserId = new();

                    foreach (EmployeeModelForCheckOnAdminRightesByTUID i in coaches)
                    {
                        coachTelegramUserId.Add(i.TelegramUserId);
                    };

                    if (adminTelegramUserId.Contains(update.Message.Chat.Id))
                    {
                        return new AdministratorState();
                    }

                    else if (coachTelegramUserId.Contains(update.Message.Chat.Id))
                    {
                        return new CoachState();
                    }

                    else
                    {
                        return new StartState(update.Message.Chat.FirstName);
                    }
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
                    { InlineKeyboardButton.WithCallbackData("Посмотреть расписание тренировок", "ClientTimetableState"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Посмотреть свои записи", "1"),},
                });

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, $"Здравствуйте {_name}, добро пожаловать в наш фитнес клуб!", replyMarkup: inlineKeyboard);
        }
    }
}
