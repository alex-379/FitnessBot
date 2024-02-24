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
                cfg.AddProfile(new SportTypeMappingProfile());
            });

            _mapper = new Mapper(config);
        }

        public List<EmployeeOutputModelForCheckOnAdminRightesByTUID> GetAllPersonsByRoleId(int roleId)
        {
            List<PersonDto> personDTos = _personRepository.GetAllPersonsByRoleId(roleId);

            return _mapper.Map<List<EmployeeOutputModelForCheckOnAdminRightesByTUID>>(personDTos);
        }

        public void AddPersonWithOtp(RegistrationEmployeeByOtpInputModel person)
        {
            PersonRepository personRepository = new();
            var a = _mapper.Map<PersonDto>(person);
            personRepository.AddPerson(a);
        }

        public void AddPerson(RegistrationPersonInputModel person)
        {

        }

        public List<ClientAndAdministratorOutputModel> GetAllPersons()
        {
            List <PersonDto> personDTos = _personRepository.GetAllPersons();

            return _mapper.Map<List<ClientAndAdministratorOutputModel>>(personDTos);
        }

        public List<CoachWithSportTypesOutputModel> GetAllCoachesWithSportTypes()
        {
            List<PersonDto> personDTos = _personRepository.GetAllCoachesWithSportTypesWorkoutTypes();

            return _mapper.Map<List<CoachWithSportTypesOutputModel>>(personDTos);
        }

        public ClientAndAdministratorOutputModel GetPersonById(int id)
        {
            PersonDto personDTo = _personRepository.GetPersonById(id);

            return _mapper.Map<ClientAndAdministratorOutputModel>(personDTo);
        }

        public List<CoachWithTgId> GetCoachesWithTgIdByRoleId(int roleId)
        {
            List<PersonDto> personDTos = _personRepository.GetAllPersonsByRoleId(roleId);

            return _mapper.Map<List<CoachWithTgId>>(personDTos);
        }

    }
}