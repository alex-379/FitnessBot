using FitnessClub.DAL.Dtos;

namespace FitnessClub.DAL.IRepositories
{
    public interface ITimetableRepository
    {
        public int? AddTimetable(TimetableDto timetable);

        public void AddClientTimetable(int clientId, int timetableId);

        public List<TimetableDto> GetAllTimetables();

        public TimetableDto GetTimetableById(int id);

        public void UpdateTimetableById(TimetableDto person);

        public void DeleteTimetableById(TimetableDto timetable);

        public void DeleteClientTimetable(int clientId, int timetableId);

        public List<TimetableDto> GetTimetableWithWorkoutById();

        public List<TimetableDto> GetAllTimetablesWithWorkouts();

        public List<TimetableDto> GetAllDeletedTimetablesWithWorkouts();

        public List<TimetableDto> GetAllTimetablesWithWorkoutsClients();

        public List<TimetableDto> GetTimetableWithWorkoutsClientsById();
    }
}