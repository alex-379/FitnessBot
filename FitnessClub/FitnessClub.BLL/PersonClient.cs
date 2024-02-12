using FitnessClub.BLL.Models.PersonModels.InputModels;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using FitnessClub.DAL;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.IRepositories;
using AutoMapper;
using FitnessClub.BLL.Mapping;

namespace FitnessClub.BLL
{
    public class PersonClient
    {
        private IPersonRepository _personRepository;
        private Mapper _mapper; 

        public PersonClient()
        {
            _personRepository = new PersonRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PersonMappingProfile());
            });

            _mapper = new Mapper(config);
        }

        public void AddPerson(ClientAndAdministratorInputModel person)
        {

        }

        public List<PersonOutputModel> GetAllPersons()
        {
            List <PersonDto> personDTos = _personRepository.GetAllPersons();

            return _mapper.Map<List<PersonOutputModel>>(personDTos);
        }

    }
}
