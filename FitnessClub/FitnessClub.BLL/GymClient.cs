using AutoMapper;
using FitnessClub.BLL.Mapping;
using FitnessClub.BLL.Models.SportTypeModels;
using FitnessClub.DAL;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.IRepositories;

namespace FitnessClub.BLL
{
    public class GymClient
    {
        private IGymRepository _gymRepository;
        private Mapper _mapper;

        public GymClient()
        {
            _gymRepository = new GymRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SportTypeMappingProfile());
            });

            _mapper = new Mapper(config);
        }

        public List<SportTypeOutputModel> GetAllSportTypes()
        {
            List<SportTypeDto> sportTypeDtos = _sportTypeRepository.GetAllSportTypes();

            return _mapper.Map<List<SportTypeOutputModel>>(sportTypeDtos);
        }
}
