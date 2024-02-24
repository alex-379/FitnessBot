namespace FitnessClub.BLL.Models.PersonModels.InputModels
{
    public class RegistrationPersonInputModel
    {
        public int RoleId { get; set; }

        public string? FamilyName { get; set; }

        public string? FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? DateBirth { get; set; }

        public bool? Sex { get; set; }

        public long TelegramUserId { get; set; }
    }
}