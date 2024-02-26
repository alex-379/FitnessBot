using FitnessClub.BLL.Models.PersonModels.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class AdministratorPersonalInfoStateClients : AbstractState
    {
        int count = 0;

        public override AbstractState ReceiveMessage(Update update)
        {
            return this;
        }

        public override void SendMessage(long chatId)
        {
            {
                var administrators = _personClient.GetAllAdministrators();
                List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();

                foreach (AdministratorOutputModel a in administrators)
                {
                    if (count % 2 == 0)
                    {
                        buttons.Add(new List<InlineKeyboardButton>());
                    }
                    buttons[buttons.Count - 1].Add(new InlineKeyboardButton($"{a.TelegramUserId}") { CallbackData = ($"{a.TelegramUserId}") });
                    count++;
                }

                InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Просмотр персонала", replyMarkup: inlineKeyboard);
            }
        }
    }
}