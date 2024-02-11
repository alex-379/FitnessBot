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

        public void UpdatePersonById(PersonDto person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<PersonDto>(PersonStoredProcedures.UpdatePersonById,
                    new {person.Id, person.RoleId, person.FamilyName, person.FirstName, person.Patronymic, person.PhoneNumber, person.Email, person.DateBirth, person.Sex },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeletePersonById(PersonDto person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<PersonDto>(PersonStoredProcedures.DeletePersonById,
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

        public List<PersonDto> GetAllCoachesWithSportTypesWorkoutTypes()
        {
            const int roleId = 2;

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

    }
}
