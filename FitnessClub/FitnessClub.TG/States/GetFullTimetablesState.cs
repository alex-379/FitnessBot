using FitnessClub.BLL;
using FitnessClub.BLL.Models.SportTypeModels;
using FitnessClub.BLL.Models.TimetableModels.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FitnessClub.TG.States
{
    public class GetFullTimetablesState : AbstractState
    {
        int i = 0;
        string sportType;
        int workoutType;
        string date;

        public override AbstractState ReceiveMessage(Update update)
        {
            if (i == 0)
            {
                sportType = update.CallbackQuery.Data;
            }

            if (i == 1)
            {
                workoutType = Convert.ToInt32(update.CallbackQuery.Data);
            }

            if (i == 2)
            {
                date = update.CallbackQuery.Data;
            }

            if (update.Type == UpdateType.Message)
            {
                return new StartState(update.Message.Chat.FirstName);
            }
            i++;
            return this;
        }

        public override void SendMessage(long ChatId)
        {
            if (i == 0)
            {
                SportTypeClient sportTypeClient = new();
                List<SportTypeNameOutputModel> sportTypes = sportTypeClient.GetAllSportTypesNames();
                List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
                int count = 0;
                foreach (SportTypeNameOutputModel s in sportTypes)
                {
                    if (count % 2 == 0)
                    {
                        buttons.Add(new List<InlineKeyboardButton>());
                    }
                    buttons[buttons.Count - 1].Add(new InlineKeyboardButton(s.SportType) { CallbackData = (s.SportType) });
                    count++;
                }

                InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, "Выберите вид спорта:", replyMarkup: inlineKeyboard);
            }

            if (i == 1)
            {
                Console.WriteLine(sportType);
                var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Индивидуальная", "1"),},
                        new InlineKeyboardButton[]
                        { InlineKeyboardButton.WithCallbackData("Групповая", "2"),},
                });
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, "Выберите тип тренировки:", replyMarkup: inlineKeyboard);
            }

            if (i == 2)
            {
                Console.WriteLine(workoutType);
                TimetableClient timetableClient = new();
                List<TimetableOutputModel> dates = timetableClient.GetTimetableDates();
                List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
                int count = 0;
                foreach (TimetableOutputModel d in dates)
                {
                    if (count % 3 == 0)
                    {
                        buttons.Add(new List<InlineKeyboardButton>());
                    }
                    buttons[buttons.Count - 1].Add(new InlineKeyboardButton(d.Date) { CallbackData = (d.Date) });
                    count++;
                }

                InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(ChatId, "Выберите дату:", replyMarkup: inlineKeyboard);
            }
        }
    }
}

