using Dapper;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.IRepositories;
using FitnessClub.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClub.DAL
{
    public class PersonRepository : IPersonRepository
    {
        public void AddPerson(PersonDto person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<PersonDto>(PersonStoredProcedures.AddPerson,
                    new { person.RoleId, person.FamilyName, person.FirstName, person.Patronymic, person.PhoneNumber, person.Email, person.DateBirth, person.Sex},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddCoachSportType()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {

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

        public void UpdatePersonById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {

            }
        }

        public List<PersonDto> GetAllPersonsByRoleId(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<PersonDto, RoleDto, PersonDto>(PersonStoredProcedures.GetAllPersonsByRoleId,
                    (person, role) =>
                    {
                        person.RoleId = id;
                        person.Role = role;
                        return person;
                    },
                    splitOn:"Id",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
