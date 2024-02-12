namespace FitnessClub.DAL.Dtos
{
    public class PersonDto
    {
        public PersonDto()
        {
            SportTypes = new List<SportTypeDto>();

            WorkoutTypes = new List<WorkoutTypeDto>();
        }

        public int? Id { get; set; }

        public int? RoleId { get; set; }

        public string? FamilyName { get; set; }

        public string? FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? DateBirth { get; set; }

        public bool? Sex { get; set; }

        public List<SportTypeDto> SportTypes { get; set; }

        public List<WorkoutTypeDto> WorkoutTypes { get; set; }

        public RoleDto Role { get; set; }
    }
}