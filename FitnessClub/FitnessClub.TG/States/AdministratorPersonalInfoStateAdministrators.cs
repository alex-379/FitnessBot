using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class AdministratorPersonalInfoStateAdministrators : AbstractState
    {
        int count = 0;
        private SportTypeClient _sportTypeClient;
        private PersonClient personClient;

        public AdministratorPersonalInfoStateAdministrators()
        {
            _sportTypeClient = new();
            _personClient = new();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            return this;
        }

        public override void SendMessage(long chatId)
        {
            //var sportTypes = _sportTypeClient.GetAllSportTypesNames();
            //List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();

            //foreach (SportTypeNameOutputModel s in sportTypes)
            //{
            //    if (count % 2 == 0)
            //    {
            //        buttons.Add(new List<InlineKeyboardButton>());
            //    }
            //    buttons[buttons.Count - 1].Add(new InlineKeyboardButton(s.SportType) { CallbackData = (s.SportType) });
            //    count++;
            //}

            //InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
            //SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите вид спорта:", replyMarkup: inlineKeyboard);




            var administrators = _personClient.GetAllAdministrators();
            List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();

            foreach (AdministratorOutputModel a in administrators)
            {
                if (count % 2 == 0)
                {
                    buttons.Add(new List<InlineKeyboardButton>());
                }
                buttons[buttons.Count - 1].Add(new InlineKeyboardButton(a.FamilyName) { CallbackData = (a.FamilyName) });
                count++;
            }

            InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите вид спорта:", replyMarkup: inlineKeyboard);


        }
    }
}