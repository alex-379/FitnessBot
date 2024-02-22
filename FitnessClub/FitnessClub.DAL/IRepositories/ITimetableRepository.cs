using FitnessClub.DAL.Dtos;

namespace FitnessClub.DAL.IRepositories
{
    public interface ITimetableRepository
    {
        public int? AddTimetable(TimetableDto timetable);

        public void AddClientTimetable(int clientId, int timetableId);

        public List<TimetableDto> GetAllTimetables();

        public List<TimetableDto> GetAllActiveTimetables();

        public List<TimetableDto> GetAllArchiveTimetables();

        public TimetableDto GetTimetableById(int id);

        public void UpdateTimetableOnId(TimetableDto person);

        public void DeleteTimetableById(int id);

        public void UndeleteTimetableById(int id);

        public void DeleteClientTimetable(int clientId, int timetableId);

        public List<TimetableDto> GetAllTimetablesWithCoachWorkoutsGymsClients ();

        public TimetableDto GetTimetableWithCoachWorkoutsGymsClientsById(int id);
    }
}