using FitnessClub.DAL.Dtos;

namespace FitnessClub.DAL.IRepositories
{
    public interface ITimetableRepository
    {
        public void AddTimetable(TimetableDto timetable);

        public void AddClientTimetable(TimetableDto timetable);

        public void DeleteTimetableById(TimetableDto timetable);

        public void DeleteClientTimetable(TimetableDto timetable);

        public List<TimetableDto> GetTimetableWithWorkoutById();

        public List<TimetableDto> GetAllTimetablesWithWorkouts();

        public List<TimetableDto> GetAllDeletedTimetablesWithWorkouts();
    }
}