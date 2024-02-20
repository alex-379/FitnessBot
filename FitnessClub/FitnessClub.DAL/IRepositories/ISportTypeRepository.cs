using FitnessClub.DAL.Dtos;

namespace FitnessClub.DAL.IRepositories
{
    public interface ISportTypeRepository
    {
        public List<SportTypeDto> GetAllSportTypes();
    }
}