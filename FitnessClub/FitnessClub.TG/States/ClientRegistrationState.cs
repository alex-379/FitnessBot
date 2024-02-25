using FitnessClub.BLL.Models.PersonModels.OutputModels;
using FitnessClub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using System.ComponentModel.DataAnnotations;
using FitnessClub.BLL.Models.PersonModels.InputModels;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class ClientRegistrationState : AbstractState
    {
        int i = 0;

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var upd = update.Message;

                if (i == 0)
                {
                    FamilyName = upd.Text;
                }

                if (i == 1)
                {
                    FirstName = upd.Text;
                }

                if (i == 2)
                {
                    PhoneNumber = upd.Text;
                    RoleId = 3;
                    TelegramUserId = upd.Chat.Id;

                    RegistrationPersonInputModel client = new RegistrationPersonInputModel
                    {
                        RoleId = 3,
                        FamilyName = FamilyName,
                        FirstName = FirstName,
                        TelegramUserId = (long)TelegramUserId,
                        PhoneNumber = PhoneNumber
                    };
                    PersonClient personClient = new();
                    personClient.AddPerson(client);
                }
                i++;
            }

            if (update.Type == UpdateType.CallbackQuery)
            {
                if (update.CallbackQuery.Data == "ClientAllTimetableState")
                {
                    return new ClientAllTimetableState();
                }
            }

            return this;
        }

        public override void SendMessage(long chatId)
        {
            long crntTelegramUserId = 00000;
            if (i == 0)
            {
                PersonClient personClient = new();
                List<ClientAndAdministratorOutputModel> persons = personClient.GetAllPersons();

                foreach (var a in persons)
                {
                    if (a.TelegramUserId == chatId)
                    {
                        crntTelegramUserId = (long)a.TelegramUserId;
                    }
                }

                if (crntTelegramUserId == chatId)
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(
                        new List<InlineKeyboardButton[]>()
                        {
                         new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Посмотреть расписание тренировок", "ClientAllTimetableState"),},}
                        );

                    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Вход в личный кабинет выполнен.", replyMarkup: inlineKeyboard);
                }

                else
                {
                    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Здравствуйте, давайте зарегистрируем Вас в системе. " +
                    "Это займет немного времени. Напишите, пожалуйста, Вашу фамилию:");
                }
            }

            if (i == 1)
            {
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Напишите, пожалуйста, Ваше имя:");
            }

            if (i == 2)
            {
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Напишите, пожалуйста, Ваш номер телефона:");
            }

            if (i == 3)
            {
                var inlineKeyboard = new InlineKeyboardMarkup(
               new List<InlineKeyboardButton[]>()
               {
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Посмотреть расписание тренировок", "ClientAllTimetableState"),},
               });

                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Поздравляем, Вы успешно зарегистрированы!", replyMarkup: inlineKeyboard);
            }
        }
    }
}
