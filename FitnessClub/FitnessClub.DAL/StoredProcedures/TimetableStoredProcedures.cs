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

        public const string GetAllTimetablesWithCoachWorkoutsGymsClients = "GetAllTimetablesWithCoachWorkoutsGymsClients";

        public const string GetTimetableWithCoachWorkoutsGymsClientsById = "GetTimetableWithCoachWorkoutsGymsClientsById";
    }
}