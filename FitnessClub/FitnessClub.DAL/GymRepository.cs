using Dapper;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClub.DAL
{
    public class GymRepository
    {
        public List<GymDto> GetAllGyms()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<GymDto>(GymsStoredProcedures.GetAllGyms,
                commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}