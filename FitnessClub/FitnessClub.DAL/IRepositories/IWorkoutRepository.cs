using FitnessClub.DAL.Dtos;

namespace FitnessClub.DAL.IRepositories
{
    public interface IWorkoutRepository
    {
        public int? AddWorkout(WorkoutDto workout);

        public List<WorkoutDto> GetAllWorkouts();

        public WorkoutDto GetWorkoutById(int id);

        public void UpdateWorkoutOnId(WorkoutDto workouts);

        public void DeleteWorkoutById(int id);

        public void UndeleteWorkoutById(int id);

        public List<WorkoutDto> GetAllWorkoutsWithSportType();

        public WorkoutDto GetWorkoutWithSportTypeById(int id);

        public List<WorkoutDto> GetAllWorkoutsWithSportTypeBySportTypeId(int sportTypeId);
    }
}
