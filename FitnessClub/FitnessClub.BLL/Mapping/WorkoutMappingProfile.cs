using AutoMapper;
using FitnessClub.BLL.Models.WorkoutModels.OutputModels;
using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Mapping
{
    public class WorkoutMappingProfile : Profile
    {
        public WorkoutMappingProfile()
        {
            CreateMap<WorkoutDto, WorkoutOutputModel>();
        }
    }
}