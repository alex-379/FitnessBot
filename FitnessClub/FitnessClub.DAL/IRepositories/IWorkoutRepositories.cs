using FitnessClub.DAL.Dtos;

namespace FitnessClub.DAL.IRepositories
{
    public interface IWorkoutRepositories
    {
        public int? AddWorkout(WorkoutDto workout);

        public List<WorkoutDto> GetAllWorkouts();

        public WorkoutDto GetWorkoutById(int id);

        public void UpdateWorkoutById(WorkoutDto workouts);

        public void DeleteWorkoutById(WorkoutDto workout);

        public List<WorkoutDto> GetWorkoutWithSportTypes();

        public List<WorkoutDto> GetWorkoutWithSportTypeCoaches();
    }
}
