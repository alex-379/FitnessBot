using FitnessClub.DAL.Dtos;

namespace FitnessClub.DAL.IRepositories
{
    public interface IWorkoutRepositories
    {
        public void AddWorkouts(WorkoutDto workout);

        public void DeleteWorkoutsById(WorkoutDto workout);

        public void UpdateWorkoutsById(WorkoutDto workouts);

        public List<WorkoutDto> GetAllWorkots();

        public List<WorkoutDto> GetWorkoutsById();
    }
}
