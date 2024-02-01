using FitnessClub.DAL.DTOs;
using FitnessClub.DAL.IRepositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.DAL
{
    public class PersonRepository : IPersonRepository
    {
        public List<PersonDTO> GetAllPersons()
        {
            using ()
            {
                IDbConnection connection = new SqlConnection(connectionString)
            }

        }
    }
}
