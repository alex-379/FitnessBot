using FitnessClub.DAL.DTOs;
using FitnessClub.DAL.IRepositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FitnessClub.DAL.StoredProcedures;

namespace FitnessClub.DAL
{
    public class PersonRepository : IPersonRepository
    {
        //public void AddPerson(int roleId, string familyName, string firstName, string patronymic, string phoneNumber, string email, string dateBirth, bool sex)
        //{
        //    using (IDbConnection connection = new SqlConnection(Options.connectionString))
        //    {
        //        return connection.QuerySingle<PersonDTO>(PersonStoredProcedures.AddPerson, new { roleId, familyName, firstName, patronymic, phoneNumber, email, dateBirth, sex }, commandType: CommandType.StoredProcedure);
        //    }
        //}

        public List<PersonDTO> GetAllPersons()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<PersonDTO>(PersonStoredProcedures.GetAllPersons, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public PersonDTO GetPersonById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.QuerySingle<PersonDTO>(PersonStoredProcedures.GetPersonById, new {id}, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
