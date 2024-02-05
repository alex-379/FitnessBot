using Dapper;
using FitnessClub.DAL.DTOs;
using FitnessClub.DAL.IRepositories;
using FitnessClub.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClub.DAL
{
    public class PersonRepository : IPersonRepository
    {
        public void AddPerson(PersonDTO person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<PersonDTO>(PersonStoredProcedures.AddPerson,
                    new {person.RoleId, person.FamilyName, person.FirstName, person.Patronymic, person.PhoneNumber, person.Email, person.DateBirth, person.Sex},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddCoachSportType(PersonDTO person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<PersonDTO>(PersonStoredProcedures.AddPerson,
                    new { person.RoleId, person.FamilyName, person.FirstName, person.Patronymic, person.PhoneNumber, person.Email, person.DateBirth, person.Sex },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<PersonDTO> GetAllPersons()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<PersonDTO>(PersonStoredProcedures.GetAllPersons,commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public PersonDTO GetPersonById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.QuerySingle<PersonDTO>(PersonStoredProcedures.GetPersonById, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
