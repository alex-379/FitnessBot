namespace FitnessClub.BLL.Models.TimetableModels.OutputModels
{
    public class GetTimetablesOutputModel
    {
        public int Id { get; set; }

        public string? DateTime { get; set; }

        public int CoachId { get; set; }

        public int WorkoutId { get; set; }

        public int GymId { get; set; }
    }
}
