using FitnessClub.DAL.Dtos;

namespace FitnessClub.DAL.IRepositories
{
    public interface IWorkoutRepositories
    {
        public int? AddWorkout(WorkoutDto workout);

        public List<WorkoutDto> GetAllWorkouts();

        public WorkoutDto GetWorkoutById(int id);

        public void UpdateWorkoutOnId(WorkoutDto workouts);

        public void DeleteWorkoutOnId(WorkoutDto workout);

        public List<WorkoutDto> GetAllWorkoutsWithSportType();

        public WorkoutDto GetWorkoutWithSportTypeById(int id);

        public List<WorkoutDto> GetWorkoutsWithSportTypeBySportTypeId(int sportTypeId);
    }
}
