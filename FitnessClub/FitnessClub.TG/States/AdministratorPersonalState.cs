using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class AdministratorPersonalState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (callback == "AdministratorPersonalRegistrationState")
                {
                    return new AdministratorPersonalRegistrationState();
                }
                if (callback == "AdministratorPersonalInfoState")
                {
                    return new AdministratorPersonalInfoState();
                }
                if (callback == "AdministratorPersonalChangeState")
                {
                    return new AdministratorPersonalChangeState();
                }
            }

            return this;
        }

        public override void SendMessage(long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Регистрация нового сотрудника", "AdministratorPersonalRegistrationState"),
                    InlineKeyboardButton.WithCallbackData("Просмотр информации", "AdministratorPersonalInfoState")},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Внесение изменений", "AdministratorPersonalChangeState"),
                     InlineKeyboardButton.WithCallbackData("Удаление", "AdministratorPersonalChangeState")},
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Администрирование персонала", replyMarkup: inlineKeyboard);
        }
    }
}