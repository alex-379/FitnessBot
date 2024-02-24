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

                if (callback == "AdministratorPersonalRegistrationState")
                {
                    return new AdministratorPersonalRegistrationState();
                }
                if (callback == "AdministratorWorkoutsState")
                {
                    return new AdministratorWorkoutsState();
                }
                if (callback == "AdministratorTimetablesState")
                {
                    return new AdministratorTimetablesState();
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
                    { InlineKeyboardButton.WithCallbackData("По TelegramUserID", "AdministratorPersonalRegistrationStateByTUID"),
                    InlineKeyboardButton.WithCallbackData("По OTP", "AdministratorPersonalInfoStateByOTP")}
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Администрирование персонала", replyMarkup: inlineKeyboard);
        }
    }
}