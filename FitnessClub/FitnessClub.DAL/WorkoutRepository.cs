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

        public List<WorkoutDto> GetAllWorkoutsWithSportType()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                Dictionary<int, WorkoutDto> workouts = new();

                connection.Query<WorkoutDto, SportTypeDto, WorkoutDto>(WorkoutStoredProcedures.GetAllWorkoutsWithSportType,
                        (workout, sportType) =>
                        {
                            if (!workouts.ContainsKey((int)workout.Id))
                            {
                                workouts.Add((int)workout.Id, workout);
                            }

                            WorkoutDto crntWorkout = workouts[(int)workout.Id];

                            crntWorkout.SportType = sportType;

                            return crntWorkout;
                        },
                        splitOn: "SportTypeId",
                        commandType: CommandType.StoredProcedure);

                return workouts.Values.ToList();
            }
        }

        public WorkoutDto GetWorkoutWithSportTypeById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                Dictionary<int, WorkoutDto> workouts = new();

                connection.Query<WorkoutDto, SportTypeDto, WorkoutDto>(WorkoutStoredProcedures.GetWorkoutWithSportTypeById,
                        (workout, sportType) =>
                        {
                            if (!workouts.ContainsKey(id))
                            {
                                workouts.Add(id, workout);
                            }

                            WorkoutDto crntWorkout = workouts[id];

                            crntWorkout.SportType = sportType;

                            return crntWorkout;
                        },
                        new { id },
                        splitOn: "SportTypeId",
                        commandType: CommandType.StoredProcedure);

                return workouts[id];
            }
        }

        public List<WorkoutDto> GetWorkoutsWithSportTypeBySportTypeId(int sportTypeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                Dictionary<int, WorkoutDto> workouts = new();

                connection.Query<WorkoutDto, SportTypeDto, WorkoutDto>(WorkoutStoredProcedures.GetWorkoutsWithSportTypeBySportTypeId,
                        (workout, sportType) =>
                        {
                            if (!workouts.ContainsKey((int)workout.Id))
                            {
                                workouts.Add((int)workout.Id, workout);
                            }

                            WorkoutDto crntWorkout = workouts[(int)workout.Id];

                            crntWorkout.SportType = sportType;

                            return crntWorkout;
                        },
                        new { sportTypeId },
                        splitOn: "SportTypeId",
                        commandType: CommandType.StoredProcedure);

                return workouts.Values.ToList();
            }
        }
    }
}