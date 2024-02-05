using FitnessClub.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FitnessClub.DAL.IRepositories
{
    public interface ITimetableRepository
    {
        public void AddTimetable(TimetableDTO timetable);
        public void AddClientTimetable(TimetableDTO timetable);
        public void DeleteTimetableById(TimetableDTO timetable);
        public void DeleteClientTimetable(TimetableDTO timetable);
        public List<TimetableDTO> GetTimetableWithWorkoutById();
        public List<TimetableDTO> GetAllTimetablesWithWorkouts();
        public List<TimetableDTO> GetAllDeletedTimetablesWithWorkouts();
    }
}
