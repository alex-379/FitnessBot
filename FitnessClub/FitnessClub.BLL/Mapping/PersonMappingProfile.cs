using AutoMapper;
using FitnessClub.BLL.Models.PersonModels.InputModels;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Mapping
{
    public class PersonMappingProfile:Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<PersonDto, ClientAndAdministratorOutputModel>();

            CreateMap<ClientAndAdministratorInputModel, PersonDto>();
        }
    }
}
