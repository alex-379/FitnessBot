﻿using FitnessClub.DAL.Dtos;
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
        public void AddWorkouts(WorkoutDto workout)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(WorkoutStoredProcedures.AddWorkouts, new {workout.SportTypeId, workout.Price, workout.Duration, workout.NumberPlaces},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteWorkoutsById(WorkoutDto workout)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(WorkoutStoredProcedures.DeleteWorkoutsById, new {workout.Id},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateWorkoutsById(WorkoutDto workout)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query(WorkoutStoredProcedures.UpdateWorkoutsById, new { workout.SportTypeId, workout.Price, workout.Duration, workout.NumberPlaces},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<WorkoutDto> GetAllWorkots()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<WorkoutDto>(WorkoutStoredProcedures.GetAllWorkouts,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<WorkoutDto> GetWorkoutsById()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<WorkoutDto>(WorkoutStoredProcedures.GetWorkoutsById,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
