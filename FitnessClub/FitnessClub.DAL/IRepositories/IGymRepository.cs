using FitnessClub.DAL.Dtos;

namespace FitnessClub.DAL.IRepositories
{
    public interface IGymRepository
    {
        public List<GymDto> GetAllGyms();
    }
}