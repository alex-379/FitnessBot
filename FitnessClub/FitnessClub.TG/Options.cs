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
    }
}