namespace FitnessClub.TG.Models.TimetableModels.InputModels
{
    public class ClientAllTimetableInputModel
    {
        public string? SportType { get; set; }

        public bool? WorkoutType { get; set; }

        public string? Date { get; set; }

        public int? TimetableId { get; set; }

        public int ClientId { get; set; }

        public long? TelegramUserId { get; set; }
    }
}
