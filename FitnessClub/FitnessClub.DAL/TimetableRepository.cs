using Dapper;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.IRepositories;
using FitnessClub.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClub.DAL
{
    public class TimetableRepository : ITimetableRepository
    {
        public void AddTimetable(TimetableDto timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(TimetableStoredProcedures.AddTimetable, new { timetable.DateTime, timetable.CoachId, timetable.WorkoutId, timetable.GymId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddClientTimetable(TimetableDto timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(TimetableStoredProcedures.AddClientTimetable, new { timetable.ClientId, timetable.TimetableId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteTimetableById(TimetableDto timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(TimetableStoredProcedures.DeleteTimetableById, new { timetable.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteClientTimetable(TimetableDto timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(TimetableStoredProcedures.DeleteClientTimetable, new { timetable.ClientId, timetable.TimetableId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<TimetableDto> GetTimetableWithWorkoutById()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<TimetableDto, PersonDto, GymDto, SportTypeDto, WorkoutTypeDto, WorkoutDto, TimetableDto>
                    (TimetableStoredProcedures.GetTimetableWithWorkoutById,
                    (timetable, coach, gym, sportType, workoutType, workout) =>
                    {
                        timetable.Person = coach;
                        timetable.Gym = gym;
                        timetable.SportType = sportType;
                        timetable.WorkoutType = workoutType;
                        timetable.Workout = workout;
                        return timetable;
                    },
                    splitOn: "id",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<TimetableDto> GetAllTimetablesWithWorkouts()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<TimetableDto, PersonDto, GymDto, SportTypeDto, WorkoutTypeDto, WorkoutDto, TimetableDto>
                    (TimetableStoredProcedures.GetAllTimetablesWithWorkouts,
                    (timetable, coach, gym, sportType, workoutType, workout) =>
                    {
                        timetable.Person = coach;
                        timetable.Gym = gym;
                        timetable.SportType = sportType;
                        timetable.WorkoutType = workoutType;
                        timetable.Workout = workout;
                        return timetable;
                    },
                    splitOn: "id",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<TimetableDto> GetAllDeletedTimetablesWithWorkouts()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<TimetableDto, PersonDto, GymDto, SportTypeDto, WorkoutTypeDto, WorkoutDto, TimetableDto>
                    (TimetableStoredProcedures.GetAllDeletedTimetablesWithWorkouts,
                    (timetable, coach, gym, sportType, workoutType, workout) =>
                    {
                        timetable.Person = coach;
                        timetable.Gym = gym;
                        timetable.SportType = sportType;
                        timetable.WorkoutType = workoutType;
                        timetable.Workout = workout;
                        return timetable;
                    },
                    splitOn: "id",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<TimetableDto> GetAllTimetablesWithWorkoutsClients()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                Dictionary<int, TimetableDto> timetableClients = new Dictionary<int, TimetableDto>();

                connection.Query<TimetableDto, PersonDto, GymDto, SportTypeDto, WorkoutTypeDto, WorkoutDto, PersonDto, TimetableDto>
                   (TimetableStoredProcedures.GetAllTimetablesWithWorkoutsClients,
                   (timetable, coach, gym, sportType, workoutType, workout, client) =>
                   {
                       timetable.Person = coach;
                       timetable.Gym = gym;
                       timetable.SportType = sportType;
                       timetable.WorkoutType = workoutType;
                       timetable.Workout = workout;

                       if (!timetableClients.ContainsKey((int)timetable.Id))
                       {
                           timetableClients.Add((int)timetable.Id, timetable);
                       }

                       TimetableDto crntTimetable = timetableClients[(int)timetable.Id];

                       crntTimetable.Clients.Add(client);

                       return crntTimetable;
                   },
                   splitOn: "id",
                   commandType: CommandType.StoredProcedure);

                return timetableClients.Values.ToList();
            }
        }
        public List<TimetableDto> GetTimetableWithWorkoutsClientsById()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                Dictionary<int, TimetableDto> timetableClients = new Dictionary<int, TimetableDto>();

                connection.Query<TimetableDto, PersonDto, GymDto, SportTypeDto, WorkoutTypeDto, WorkoutDto, PersonDto, TimetableDto>
                   (TimetableStoredProcedures.GetTimetableWithWorkoutsClientsById,
                   (timetable, coach, gym, sportType, workoutType, workout, client) =>
                   {
                       timetable.Person = coach;
                       timetable.Gym = gym;
                       timetable.SportType = sportType;
                       timetable.WorkoutType = workoutType;
                       timetable.Workout = workout;

                       if (!timetableClients.ContainsKey((int)timetable.Id))
                       {
                           timetableClients.Add((int)timetable.Id, timetable);
                       }

                       TimetableDto crntTimetable = timetableClients[(int)timetable.Id];

                       crntTimetable.Clients.Add(client);

                       return crntTimetable;
                   },
                   splitOn: "id",
                   commandType: CommandType.StoredProcedure);

                return timetableClients.Values.ToList();
            }
        }

    }
}
