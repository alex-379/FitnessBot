namespace FitnessClub.DAL.StoredProcedures
{
    public class TimetableStoredProcedures
    {
        public const string AddTimetable = "AddTimetable";

        public const string AddClientTimetable = "AddClientTimetable";

        public const string DeleteTimetableById = "DeleteTimetableById";

        public const string DeleteClientTimetable = "DeleteClientTimetable";

        public const string GetTimetableWithWorkoutById = "GetTimetableWithWorkoutById";

        public const string GetAllTimetablesWithWorkouts = "GetAllTimetablesWithWorkouts";

        public const string GetAllDeletedTimetablesWithWorkouts = "GetAllDeletedTimetablesWithWorkouts";
        public const string GetAllTimetablesWithWorkoutsClients = "GetAllTimetablesWithWorkoutsClients";
        public const string GetAllTimetablesWithWorkoutsClientsById = "GetAllTimetablesWithWorkoutsClientsById";
    }
}