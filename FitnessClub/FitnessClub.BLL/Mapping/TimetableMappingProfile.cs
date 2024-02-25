using AutoMapper;
using FitnessClub.BLL.Models.TimetableModels.InputModels;
using FitnessClub.BLL.Models.TimetableModels.OutputModels;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.DTOs;

namespace FitnessClub.BLL.Mapping
{
    public class TimetableMappingProfile : Profile
    {
        public TimetableMappingProfile()
        {
            CreateMap<TimetableDto, TimetableOutputModel>();

            CreateMap<ClientTimetableInputModel, ClientTimetableDTO>();

            CreateMap<AddTimetableInputModel, TimetableDto>();

            CreateMap<TimetableDto,AllTimetablesWithCoachWorkoutsGymsClientsOutputModel>();
        }
    }
}