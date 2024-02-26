using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.DTOs;

namespace FitnessClub.DAL.IRepositories
{
    public interface ITimetableRepository
    {
        public int? AddTimetable(TimetableDto timetable);

        public void AddClientTimetable(ClientTimetableDTO clientTimetable);

        public List<TimetableDto> GetAllTimetables();

        public List<TimetableDto> GetAllActiveTimetables();

        public List<TimetableDto> GetAllArchiveTimetables();

        public TimetableDto GetTimetableById(int id);

        public void UpdateTimetableOnId(TimetableDto person);

        public void DeleteTimetableById(int id);

        public void UndeleteTimetableById(int id);

        public void DeleteClientTimetable(ClientTimetableDTO clientTimetable);

        public List<TimetableDto> GetAllTimetablesWithCoachWorkoutsGymsClients ();

        public TimetableDto GetTimetableWithCoachWorkoutsGymsClientsById(int id);
    }
}