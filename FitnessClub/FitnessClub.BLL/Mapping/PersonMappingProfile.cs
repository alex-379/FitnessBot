using AutoMapper;
using FitnessClub.BLL.Models.PersonModels.InputModels;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using FitnessClub.BLL.Models.SportTypeModels;
using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Mapping
{
    public class PersonMappingProfile:Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<PersonDto, ClientAndAdministratorOutputModel>();

            CreateMap<ClientAndAdministratorInputModel, PersonDto>();

            CreateMap<PersonDto, CoachWithSportTypesOutputModel>()
                .ForMember(d=>d.FullName, opt=>opt.MapFrom(s=> $"{s.FamilyName} {s.FirstName}"));

            CreateMap<PersonDto, CoachForTimetableOutputModel>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => $"{s.FamilyName} {s.FirstName} {s.Patronymic}"));

            CreateMap<PersonDto, ClientForTimetableOutputModel>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => $"{s.FamilyName} {s.FirstName}"));
        }
    }
}
