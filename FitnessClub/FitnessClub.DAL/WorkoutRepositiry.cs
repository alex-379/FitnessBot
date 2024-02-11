using Dapper;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.IRepositories;
using FitnessClub.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClub.DAL
{
    public class WorkoutRepositiry : IWorkoutRepositories
    {
        public int? AddWorkout(WorkoutDto workout)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.QuerySingle<int>(WorkoutStoredProcedures.AddWorkout,
                    new { workout.SportTypeId, workout.Price, workout.Duration, workout.NumberPlaces, workout.IsGroup, workout.Comment },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<WorkoutDto> GetAllWorkouts()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<WorkoutDto>(WorkoutStoredProcedures.GetAllWorkouts,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public WorkoutDto GetWorkoutById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.QuerySingle<WorkoutDto>(WorkoutStoredProcedures.GetWorkoutById,
                    new { id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateWorkoutOnId(WorkoutDto workout)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(WorkoutStoredProcedures.UpdateWorkoutOnId,
                    new { workout.Id, workout.SportTypeId, workout.Price, workout.Duration, workout.NumberPlaces, workout.IsGroup, workout.Comment },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteWorkoutOnId(WorkoutDto workout)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(WorkoutStoredProcedures.DeleteWorkoutOnId,
                    new { workout.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }
        
        public List<WorkoutDto> GetWorkoutWithSportTypes()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<WorkoutDto>(WorkoutStoredProcedures.GetWorkoutWithSportTypes,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<WorkoutDto> GetWorkoutWithSportTypeCoaches()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<WorkoutDto>(WorkoutStoredProcedures.GetWorkoutWithSportTypeCoaches,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
