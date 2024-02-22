using AutoMapper;
using FitnessClub.BLL.Models.SportTypeModels;
using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Mapping
{
    public class SportTypeMappingProfile : Profile
    {
        public SportTypeMappingProfile()
        {
            CreateMap<SportTypeDto, SportTypeOutputModel>();
        }
    }
}
