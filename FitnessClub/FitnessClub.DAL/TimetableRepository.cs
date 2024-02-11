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
        public int? AddTimetable(TimetableDto timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.QuerySingle<int>(TimetableStoredProcedures.AddTimetable,
                    new { timetable.DateTime, timetable.CoachId, timetable.WorkoutId, timetable.GymId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddClientTimetable(int clientId, int timetableId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<int>(TimetableStoredProcedures.AddClientTimetable,
                    new { clientId, timetableId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<TimetableDto> GetAllTimetables()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<TimetableDto>(TimetableStoredProcedures.GetAllTimetables,
                commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public TimetableDto GetTimetableById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.QuerySingle<TimetableDto>(TimetableStoredProcedures.GetTimetableById,
                new { id },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateTimetableOnId(TimetableDto timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<TimetableDto>(TimetableStoredProcedures.UpdateTimetableOnId,
                    new { timetable.Id, timetable.DateTime, timetable.CoachId, timetable.WorkoutId, timetable.GymId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteTimetableOnId(TimetableDto timetable)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<TimetableDto>(TimetableStoredProcedures.DeleteTimetableOnId,
                    new { timetable.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteClientTimetable(int clientId, int timetableId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(TimetableStoredProcedures.DeleteClientTimetable,
                    new { clientId, timetableId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        //public List<TimetableDto> GetTimetableWithWorkoutById(int id)
        //{
        //    using (IDbConnection connection = new SqlConnection(Options.connectionString))
        //    {
        //        return connection.Query<TimetableDto, PersonDto, GymDto, SportTypeDto, WorkoutTypeDto, WorkoutDto, TimetableDto>
        //            (TimetableStoredProcedures.GetTimetableWithWorkoutById,
        //            (timetable, coach, gym, sportType, workoutType, workout) =>
        //            {
        //                timetable.Person = coach;
        //                timetable.Gym = gym;
        //                timetable.SportType = sportType;
        //                timetable.WorkoutType = workoutType;
        //                timetable.Workout = workout;
        //                return timetable;
        //            },
        //            new { id },
        //            splitOn: "id",
        //            commandType: CommandType.StoredProcedure).ToList();
        //    }
        //}

        //public List<TimetableDto> GetAllTimetablesWithWorkouts()
        //{
        //    using (IDbConnection connection = new SqlConnection(Options.connectionString))
        //    {
        //        return connection.Query<TimetableDto, PersonDto, GymDto, SportTypeDto, WorkoutTypeDto, WorkoutDto, TimetableDto>
        //            (TimetableStoredProcedures.GetAllTimetablesWithWorkouts,
        //            (timetable, coach, gym, sportType, workoutType, workout) =>
        //            {
        //                timetable.Person = coach;
        //                timetable.Gym = gym;
        //                timetable.SportType = sportType;
        //                timetable.WorkoutType = workoutType;
        //                timetable.Workout = workout;
        //                return timetable;
        //            },
        //            splitOn: "id",
        //            commandType: CommandType.StoredProcedure).ToList();
        //    }
        //}

        //public List<TimetableDto> GetAllDeletedTimetablesWithWorkouts()
        //{
        //    using (IDbConnection connection = new SqlConnection(Options.connectionString))
        //    {
        //        return connection.Query<TimetableDto, PersonDto, GymDto, SportTypeDto, WorkoutTypeDto, WorkoutDto, TimetableDto>
        //            (TimetableStoredProcedures.GetAllDeletedTimetablesWithWorkouts,
        //            (timetable, coach, gym, sportType, workoutType, workout) =>
        //            {
        //                timetable.Person = coach;
        //                timetable.Gym = gym;
        //                timetable.SportType = sportType;
        //                timetable.WorkoutType = workoutType;
        //                timetable.Workout = workout;
        //                return timetable;
        //            },
        //            splitOn: "id",
        //            commandType: CommandType.StoredProcedure).ToList();
        //    }
        //}

        //public List<TimetableDto> GetAllTimetablesWithWorkoutsClients()
        //{
        //    using (IDbConnection connection = new SqlConnection(Options.connectionString))
        //    {
        //        Dictionary<int, TimetableDto> timetableClients = new Dictionary<int, TimetableDto>();

        //        connection.Query<TimetableDto, PersonDto, GymDto, SportTypeDto, WorkoutTypeDto, WorkoutDto, PersonDto, TimetableDto>
        //           (TimetableStoredProcedures.GetAllTimetablesWithWorkoutsClients,
        //           (timetable, coach, gym, sportType, workoutType, workout, client) =>
        //           {
        //               timetable.Person = coach;
        //               timetable.Gym = gym;
        //               timetable.SportType = sportType;
        //               timetable.WorkoutType = workoutType;
        //               timetable.Workout = workout;

        //               if (!timetableClients.ContainsKey((int)timetable.Id))
        //               {
        //                   timetableClients.Add((int)timetable.Id, timetable);
        //               }

        //               TimetableDto crntTimetable = timetableClients[(int)timetable.Id];

        //               crntTimetable.Clients.Add(client);

        //               return crntTimetable;
        //           },
        //           splitOn: "id",
        //           commandType: CommandType.StoredProcedure);

        //        return timetableClients.Values.ToList();
        //    }
        //}

        //public List<TimetableDto> GetTimetableWithWorkoutsClientsById()
        //{
        //    using (IDbConnection connection = new SqlConnection(Options.connectionString))
        //    {
        //        Dictionary<int, TimetableDto> timetableClients = new Dictionary<int, TimetableDto>();

        //        connection.Query<TimetableDto, PersonDto, GymDto, SportTypeDto, WorkoutTypeDto, WorkoutDto, PersonDto, TimetableDto>
        //           (TimetableStoredProcedures.GetTimetableWithWorkoutsClientsById,
        //           (timetable, coach, gym, sportType, workoutType, workout, client) =>
        //           {
        //               timetable.Person = coach;
        //               timetable.Gym = gym;
        //               timetable.SportType = sportType;
        //               timetable.WorkoutType = workoutType;
        //               timetable.Workout = workout;

        //               if (!timetableClients.ContainsKey((int)timetable.Id))
        //               {
        //                   timetableClients.Add((int)timetable.Id, timetable);
        //               }

        //               TimetableDto crntTimetable = timetableClients[(int)timetable.Id];

        //               crntTimetable.Clients.Add(client);

        //               return crntTimetable;
        //           },
        //           splitOn: "id",
        //           commandType: CommandType.StoredProcedure);

        //        return timetableClients.Values.ToList();
        //    }
        //}



        public List<TimetableDto> GetAllTimetablesWithCoachWorkoutsGymsClients()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                Dictionary<int, TimetableDto> timetables = new Dictionary<int, TimetableDto>();

                connection.Query<TimetableDto, ClientDto, CoachDto, WorkoutDto, SportTypeDto, GymDto, TimetableDto>
                   (TimetableStoredProcedures.GetAllTimetablesWithCoachWorkoutsGymsClients,
                   (timetable, client, coach, workout, sportType, gym) =>
                   {
                       if (!timetables.ContainsKey((int)timetable.Id))
                       {
                           timetables.Add((int)timetable.Id, timetable);
                       }

                       TimetableDto crntTimetable = timetables[(int)timetable.Id];

                       crntTimetable.Clients.Add(client);
                       crntTimetable.Coach = coach;
                       crntTimetable.Workout = workout;
                       crntTimetable.SportType = sportType;
                       crntTimetable.Gym = gym;

                       return crntTimetable;
                   },
                   splitOn: "ClientId,CoachId,WorkoutId,SportTypeId,GymId",
                   commandType: CommandType.StoredProcedure);

                return timetables.Values.ToList();
            }
        }

        public TimetableDto GetTimetableWithCoachWorkoutsGymsClientsById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                Dictionary<int, TimetableDto> timetables = new Dictionary<int, TimetableDto>();

                connection.Query<TimetableDto, ClientDto, CoachDto, WorkoutDto, SportTypeDto, GymDto, TimetableDto>
                   (TimetableStoredProcedures.GetTimetableWithCoachWorkoutsGymsClientsById,
                   (timetable, client, coach, workout, sportType, gym) =>
                   {
                       if (!timetables.ContainsKey(id))
                       {
                           timetables.Add(id, timetable);
                       }

                       TimetableDto crntTimetable = timetables[id];

                       crntTimetable.Clients.Add(client);
                       crntTimetable.Coach = coach;
                       crntTimetable.Workout = workout;
                       crntTimetable.SportType = sportType;
                       crntTimetable.Gym = gym;

                       return crntTimetable;
                   },
                   new { id },
                   splitOn: "ClientId,CoachId,WorkoutId,SportTypeId,GymId",
                   commandType: CommandType.StoredProcedure);

                return timetables[id];
            }
        }
    }
}
