namespace FitnessClub.DAL.Dtos
{
    public class CoachDto
    {
        public int? CoachId { get; set; }

        public string? CoachFamilyName { get; set; }

        public string? CoachFirstName { get; set; }

        public string? CoachPatronymic { get; set; }

        public string? CoachPhoneNumber { get; set; }

        public string? CoachEmail { get; set; }

        public string? CoachDateBirth { get; set; }

        public bool? CoachSex { get; set; }
    }
}