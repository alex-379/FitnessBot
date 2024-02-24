using AutoMapper;
using FitnessClub.BLL.Models.TimetableModels.InputModels;
using FitnessClub.BLL.Models.TimetableModels.OutputModels;
using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Mapping
{
    public class TimetableMappingProfile : Profile
    {
        public TimetableMappingProfile()
        {
            CreateMap<TimetableDto, TimetableOutputModel>();

            CreateMap<AddClientTimetableInputModel, TimetableDto>();

            CreateMap<AddTimetableInputModel, TimetableDto>();

            CreateMap<TimetableDto, AllTimetablesWithCoachWorkoutsGymsClientsOutputModel>();

            CreateMap<TimetableDto, TimetableDatesOutputModel>();
        }
    }
}