using Telegram.Bot;

namespace FitnessClub.TG
{
    public class Options
    {
        public static string token
        {
            get
            {
                return Environment.GetEnvironmentVariable("FitnessClubMYPBot");
            }
        }

        public static ITelegramBotClient client = new TelegramBotClient(Options.token);
    }
}