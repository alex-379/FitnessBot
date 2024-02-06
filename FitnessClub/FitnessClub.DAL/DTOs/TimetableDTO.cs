namespace FitnessClub.DAL.Dtos
{
    public class TimetableDto
    {
        public int? Id { get; set; }

        public string DateTime { get; set; }

        public int CoachId { get; set; }

        public int WorkoutId { get; set; }

        public int GymId { get; set; }

        public WorkoutDto Workout { get; set; }

        public int? ClientId { get; set; }

        public int? TimetableId { get; set; }
    }
}