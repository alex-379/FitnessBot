using Dapper;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.IRepositories;
using FitnessClub.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClub.DAL
{
    public class SportTypeRepository:ISportTypeRepository
    {
        public List<SportTypeDto> GetAllSportTypes()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<SportTypeDto>(SportTypesStoredProcedures.GetAllSportTypes,
                commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}