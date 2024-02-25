using FitnessClub.BLL;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class AdministratorPersonalInfoState : AbstractState
    {
        private PersonClient _personClient;

        public AdministratorPersonalInfoState()
        {
            _personClient = new();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (callback == "AdministratorPersonalInfoStateClients")
                {
                    _personClient.GetAllAdministrators();

                }
                if (callback == "AdministratorPersonalInfoStateCoaches")
                {

                }
                if (callback == "AdministratorPersonalInfoStateAdministrators")
                {

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
                    { InlineKeyboardButton.WithCallbackData("Клиенты", "AdministratorPersonalInfoStateClients"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Тренеры", "AdministratorPersonalInfoStateCoaches"),},
                    new InlineKeyboardButton[]
                    { InlineKeyboardButton.WithCallbackData("Администраторы", "AdministratorPersonalInfoStateAdministrators"),},
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Просмотр персонала", replyMarkup: inlineKeyboard);
        }
    }
}