namespace FitnessClub.BLL.Models.PersonModels.OutputModels
{
    public class ClientOutputModel
    {
        public string? FamilyName { get; set; }

        public string? FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? DateBirth { get; set; }

        public bool? Sex { get; set; }

        public long? TelegramUserId { get; set; }
    }
}