using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.InputModels;
using FitnessClub.BLL.Models.SportTypeModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class AdministratorPersonalRegistrationStateByTUID : AbstractState
    {
        private int i = 0;
        private RegistrationEmployeeByTuidInputModel _personModel;
        private PersonClient _personClient;

        public AdministratorPersonalRegistrationStateByTUID()
        {
            _personModel = new();
            _personClient = new();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var callback = update.CallbackQuery.Data;

                if (i == 0)
                {
                    if (callback == "1")
                    {
                        _personModel.RoleId = 1;
                    }

                    if (callback == "2")
                    {
                        _personModel.RoleId = 2;
                    }
                }
            }

            if (update.Type == UpdateType.Message)
            {
                var message = update.Message.Text;

                if (i == 1)
                {
                    _personModel.TelegramUserId = Convert.ToInt64(message);
                    _personClient.AddPersonWithTuid(_personModel);
                    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id, "Внесена новая запись");
                    return new AdministratorState();
                }
            }
            i++;
            return this;
        }

        public override void SendMessage(long chatId)
        {
            {
                if (i == 0)
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(
                    new List<InlineKeyboardButton[]>()
                    {
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Администратор", "1"),},
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Тренер", "2"),},
                    }
                    );
                    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите роль:", replyMarkup: inlineKeyboard);
                }

                if (i == 1)
                {
                    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Введите Telegram User ID");
                }
            }
        }
    }
}