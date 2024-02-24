namespace FitnessClub.BLL.Models.TimetableModels.OutputModels
{
    public class TimetableOutputModel
    {
        public int Id { get; set; }

        public string? Date { get; set; }

        public string? StartTime { get; set; }

        public int CoachId { get; set; }

        public int WorkoutId { get; set; }

        public int GymId { get; set; }
    }
}