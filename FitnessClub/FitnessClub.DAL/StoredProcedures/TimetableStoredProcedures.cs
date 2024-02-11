namespace FitnessClub.DAL.StoredProcedures
{
    public class TimetableStoredProcedures
    {
        public const string AddTimetable = "AddTimetable";

        public const string AddClientTimetable = "AddClientTimetable";

        public const string GetAllTimetables = "GetAllTimetables";

        public const string GetTimetableById = "GetTimetableById";

        public const string UpdateTimetableOnId = "UpdateTimetableOnId";

        public const string DeleteTimetableOnId = "DeleteTimetableOnId";

        public const string DeleteClientTimetable = "DeleteClientTimetable";

        public const string GetTimetableWithWorkoutById = "GetTimetableWithWorkoutById";

        public const string GetAllTimetablesWithWorkouts = "GetAllTimetablesWithWorkouts";

        public const string GetAllDeletedTimetablesWithWorkouts = "GetAllDeletedTimetablesWithWorkouts";

        public const string GetAllTimetablesWithWorkoutsClients = "GetAllTimetablesWithWorkoutsClients";

        public const string GetTimetableWithWorkoutsClientsById = "GetTimetableWithWorkoutsClientsById";


        public const string GetAllTimetablesWithCoachWorkoutsGymsClients = "GetAllTimetablesWithCoachWorkoutsGymsClients";

        public const string GetTimetableWithCoachWorkoutsGymsClientsById = "GetTimetableWithCoachWorkoutsGymsClientsById";


    }
}