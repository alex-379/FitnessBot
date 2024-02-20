using AutoMapper;
using FitnessClub.BLL.Models.GymModels;
using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Mapping
{
    public class GymMappingProfile : Profile
    {
        public GymMappingProfile()
        {
            CreateMap<GymDto, GymOutputModel>();
        }
    }
}