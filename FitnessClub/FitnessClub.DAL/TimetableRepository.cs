using FitnessClub.DAL.DTOs;
using FitnessClub.DAL.IRepositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FitnessClub.DAL.StoredProcedures;

namespace FitnessClub.DAL
{
    public class TimetableRepository : ITimetableRepository
    {
        public void AddTimetable(TimetableDTO timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(TimetableStoredProcedures.AddTimetable, new { timetable.DateTime, timetable.CoachId, timetable.WorkoutId, timetable.GymId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddClientTimetable(TimetableDTO timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(TimetableStoredProcedures.AddClientTimetable, new { timetable.ClientId, timetable.TimetableId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteTimetableById(TimetableDTO timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(TimetableStoredProcedures.DeleteTimetableById, new { timetable.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteClientTimetable(TimetableDTO timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(TimetableStoredProcedures.DeleteClientTimetable, new { timetable.ClientId, timetable.TimetableId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<TimetableDTO> GetTimetableWithWorkoutById()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<TimetableDTO, WorkoutDTO, TimetableDTO>(TimetableStoredProcedures.GetTimetableWithWorkoutById,
                    (timetable, workout) =>
                    {
                        timetable.Workout = workout;
                        return timetable;
                    },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<TimetableDTO> GetAllTimetablesWithWorkouts()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<TimetableDTO, WorkoutDTO, TimetableDTO>(TimetableStoredProcedures.GetAllTimetablesWithWorkouts,
                    (timetable, workout) =>
                    {
                        timetable.Workout = workout;
                        return timetable;
                    },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<TimetableDTO> GetAllDeletedTimetablesWithWorkouts()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<TimetableDTO, WorkoutDTO, TimetableDTO>(TimetableStoredProcedures.GetAllDeletedTimetablesWithWorkouts,
                    (timetable, workout) =>
                    {
                        timetable.Workout = workout;
                        return timetable;
                    },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }


    }
}
