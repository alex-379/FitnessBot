using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class CoachState : AbstractState
    {
        int i = 0;
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (callback == "CoachTimetableState")
                {
                    return new CoachTimetableState();
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
                        { InlineKeyboardButton.WithCallbackData("Мои тренировки и записи", "CoachTimetableState"),},
            });
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Добро пожаловать в меню тренера!", replyMarkup: inlineKeyboard);
        }
    }
}