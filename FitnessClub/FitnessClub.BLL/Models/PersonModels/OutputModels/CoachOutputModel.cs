using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Models.PersonModels.OutputModels
{
    public class CoachOutputModel
    {
        public string? FamilyName { get; set; }

        public string? FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? DateBirth { get; set; }

        public bool? Sex { get; set; }

        public long? TelegramUserId { get; set; }

        public int? OneTimePassword { get; set; }

        public List<SportTypeDto> SportTypes { get; set; }

        public List<WorkoutTypeDto> WorkoutTypes { get; set; }
    }
}