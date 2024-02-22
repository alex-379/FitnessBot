namespace FitnessClub.DAL.StoredProcedures
{
    public class PersonStoredProcedures
    {
        public const string AddPerson = "AddPerson";

        public const string AddCoachSportType = "AddCoachSportType";

        public const string AddCoachWorkoutType = "AddCoachWorkoutType";

        public const string GetAllPersons = "GetAllPersons";

        public const string GetPersonById = "GetPersonById";

        public const string UpdatePersonOnId = "UpdatePersonOnId";

        public const string DeletePersonById = "DeletePersonById";

        public const string UndeletePersonById = "UndeletePersonById";

        public const string DeleteOneTimePasswordByPersonId = "DeleteOneTimePasswordByPersonId";

        public const string DeleteCoachSportType = "DeleteCoachSportType";

        public const string DeleteCoachWorkoutType = "DeleteCoachWorkoutType";

        public const string GetAllPersonsByRoleId = "GetAllPersonsByRoleId";

        public const string GetAllCoachesWithSportTypesWorkoutTypes = "GetAllCoachesWithSportTypesWorkoutTypes";

        public const string GetCoachWithSportTypesWorkoutTypesByCoachId = "GetCoachWithSportTypesWorkoutTypesByCoachId";
    }
}