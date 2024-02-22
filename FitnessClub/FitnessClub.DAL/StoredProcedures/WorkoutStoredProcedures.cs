namespace FitnessClub.DAL.StoredProcedures
{
    public class WorkoutStoredProcedures
    {
        public const string AddWorkout = "AddWorkout";

        public const string GetAllWorkouts = "GetAllWorkouts";

        public const string GetWorkoutById = "GetWorkoutById";

        public const string UpdateWorkoutOnId = "UpdateWorkoutOnId";

        public const string DeleteWorkoutById = "DeleteWorkoutById";

        public const string UndeleteWorkoutById = "UndeleteWorkoutById";

        public const string GetAllWorkoutsWithSportType = "GetAllWorkoutsWithSportType";

        public const string GetWorkoutWithSportTypeById = "GetWorkoutWithSportTypeById";

        public const string GetAllWorkoutsWithSportTypeBySportTypeId = "GetAllWorkoutsWithSportTypeBySportTypeId";
    }
}