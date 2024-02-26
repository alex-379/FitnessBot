using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class AdministratorPersonalRegistrationState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (callback == "AdministratorPersonalRegistrationStateByTuid")
                {
                    return new AdministratorPersonalRegistrationStateByTuid();
                }
                if (callback == "AdministratorPersonalRegistrationStateByOtp")
                {
                    return new AdministratorPersonalRegistrationStateByOtp();
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
                    { InlineKeyboardButton.WithCallbackData("По TelegramUserID", "AdministratorPersonalRegistrationStateByTuid"),
                    InlineKeyboardButton.WithCallbackData("По OTP", "AdministratorPersonalRegistrationStateByOtp")}
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Регистрация персонала", replyMarkup: inlineKeyboard);
        }
    }
}