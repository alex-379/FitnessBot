namespace FitnessClub.BLL.Models.TimetableModels.InputModels
{
    public class AddTimetableInputModel
    {
        public string DateTime { get; set; }

        public int CoachId { get; set; }

        public int WorkoutId { get; set; }

        public int GymId { get; set; }
    }
}