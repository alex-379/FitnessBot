using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class AdministratorPersonalInfoState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (callback == "AdministratorPersonalInfoStateAdministrators")
                {
                    return new AdministratorPersonalInfoStateAdministrators();
                }
                if (callback == "AdministratorPersonalInfoStateClients")
                {
                    return new AdministratorPersonalInfoStateClients();
                }
                if (callback == "AdministratorPersonalInfoStateCoaches")
                {
                    return new AdministratorPersonalInfoStateCoaches();
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
                    { InlineKeyboardButton.WithCallbackData("Администраторы", "AdministratorPersonalInfoStateAdministrators"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Клиенты", "AdministratorPersonalInfoStateClients"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Тренировки", "AdministratorPersonalInfoStateCoaches"),},
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Просмотр персонала", replyMarkup: inlineKeyboard);
        }
    }
}