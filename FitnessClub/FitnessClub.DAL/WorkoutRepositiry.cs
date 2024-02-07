using FitnessClub.DAL.DTOs;
using FitnessClub.DAL.IRepositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using FitnessClub.DAL.StoredProcedures;

namespace FitnessClub.DAL
{
    public class WorkoutRepositiry: IWorkoutRepositories
    {
        public void AddWorkouts(WorkoutDTO workout)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(WorkoutStoredProcedures.AddWorkouts, new {workout.SportTypeId, workout.Price, workout.Duration, workout.NumberPlaces},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteWorkoutsById(WorkoutDTO workout)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(WorkoutStoredProcedures.DeleteWorkoutsById, new {workout.Id},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateWorkoutsById(WorkoutDTO workout)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(WorkoutStoredProcedures.UpdateWorkoutsById, new { workout.SportTypeId, workout.Price, workout.Duration, workout.NumberPlaces},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<WorkoutDTO> GetAllWorkouts()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<WorkoutDTO>(WorkoutStoredProcedures.GetAllWorkouts,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<WorkoutDTO> GetWorkoutsById()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<WorkoutDTO>(WorkoutStoredProcedures.GetWorkoutsById,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
