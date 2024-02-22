namespace FitnessClub.DAL.StoredProcedures
{
    public class TimetableStoredProcedures
    {
        public const string AddTimetable = "AddTimetable";

        public const string AddClientTimetable = "AddClientTimetable";

        public const string GetAllTimetables = "GetAllTimetables";

        public const string GetAllActiveTimetables = "GetAllActiveTimetables";

        public const string GetAllArchiveTimetables = "GetAllArchiveTimetables";

        public const string GetTimetableById = "GetTimetableById";

        public const string UpdateTimetableOnId = "UpdateTimetableOnId";

        public const string DeleteTimetableById = "DeleteTimetableById";

        public const string UndeleteTimetableById = "UndeleteTimetableById";

        public const string DeleteClientTimetable = "DeleteClientTimetable";

        public const string GetAllTimetablesWithCoachWorkoutsGymsClients = "GetAllTimetablesWithCoachWorkoutsGymsClients";

        public const string GetTimetableWithCoachWorkoutsGymsClientsById = "GetTimetableWithCoachWorkoutsGymsClientsById";
    }
}