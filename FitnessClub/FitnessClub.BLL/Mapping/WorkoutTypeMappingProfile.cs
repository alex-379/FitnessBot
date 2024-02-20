using AutoMapper;
using FitnessClub.BLL.Models.WorkoutTypeModels;
using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Mapping
{
    public class WorkoutTypeMappingProfile : Profile
    {
        public WorkoutTypeMappingProfile()
        {
            CreateMap<WorkoutTypeDto, WorkoutTypeOutputModel>();
        }
    }
}