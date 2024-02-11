using Dapper;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.IRepositories;
using FitnessClub.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Xml;

namespace FitnessClub.DAL
{
    public class PersonRepository : IPersonRepository
    {
        public int? AddPerson(PersonDto person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.QuerySingle<int>(PersonStoredProcedures.AddPerson,
                    new { person.RoleId, person.FamilyName, person.FirstName, person.Patronymic, person.PhoneNumber, person.Email, person.DateBirth, person.Sex },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddCoachSportType(int coachId, int sportTypeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<int>(PersonStoredProcedures.AddCoachSportType,
                    new { coachId, sportTypeId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddCoachWorkoutType(int coachId, int workoutTypeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<int>(PersonStoredProcedures.AddCoachWorkoutType,
                    new { coachId, workoutTypeId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<PersonDto> GetAllPersons()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<PersonDto>(PersonStoredProcedures.GetAllPersons,
                commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public PersonDto GetPersonById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.QuerySingle<PersonDto>(PersonStoredProcedures.GetPersonById,
                new { id },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdatePersonOnId(PersonDto person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<PersonDto>(PersonStoredProcedures.UpdatePersonOnId,
                    new {person.Id, person.RoleId, person.FamilyName, person.FirstName, person.Patronymic, person.PhoneNumber, person.Email, person.DateBirth, person.Sex },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeletePersonOnId(PersonDto person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<PersonDto>(PersonStoredProcedures.DeletePersonOnId,
                    new { person.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCoachSportType(int coachId, int sportTypeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<int>(PersonStoredProcedures.DeleteCoachSportType, new { coachId, sportTypeId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCoachWorkoutType(int coachId, int workoutTypeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<int>(PersonStoredProcedures.DeleteCoachWorkoutType, new { coachId, workoutTypeId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<PersonDto> GetAllPersonsByRoleId(int roleId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<PersonDto, RoleDto, PersonDto>(PersonStoredProcedures.GetAllPersonsByRoleId,
                    (person, role) =>
                    {
                        person.Role = role;
                        return person;
                    },
                    new { roleId },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        //public List<PersonDto> GetAllCoachesWithSportTypesWorkoutTypes()
        //{
        //    const int roleId = 2;

        //    using (IDbConnection connection = new SqlConnection(Options.connectionString))
        //    {
        //        return connection.Query<PersonDto, RoleDto, List<SportTypeDto>, List<WorkoutTypeDto>, PersonDto>(PersonStoredProcedures.GetAllPersonsByRoleId,
        //            (person, role, sportTypes, workoutTypes) =>
        //            {
        //                person.Role = role;
        //                person.SportTypes = sportTypes;
        //                person.WorkoutTypes = workoutTypes;
        //                return person;
        //            },
        //            new { roleId },
        //            splitOn: "Id,CoachId,RoleId,SportTypeId,WorkoutId",
        //            commandType: CommandType.StoredProcedure).ToList();
        //    }
        //}

        public List<PersonDto> GetAllCoachesWithSportTypes()
        {
            const int roleId = 2;

            Dictionary<int, PersonDto> coaches = new();

            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<PersonDto, RoleDto, SportTypeDto, PersonDto>(PersonStoredProcedures.GetAllCoachesWithSportTypes,
                    (coach, role, sportType) =>
                    {
                        coach.Role = role;

                        if (!coaches.ContainsKey((int)coach.Id)) 
                        {
                            coaches.Add((int)coach.Id, coach);
                        }

                        PersonDto crntCoach = coaches[(int)coach.Id];

                        crntCoach.SportTypes.Add(sportType);

                        return crntCoach;
                    },
                    new { roleId },
                    splitOn: "id1",
                    commandType: CommandType.StoredProcedure);
            }

            return coaches.Values.ToList();
        }

    }
}
