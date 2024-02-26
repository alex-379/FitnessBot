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

        public List<EmployeeOutputModelForCheckOnAdminRightesByTuid> GetAllPersonsTelegramUserIdByRoleId(int roleId)
        {
            List<PersonDto> personDTos = _personRepository.GetAllPersonsByRoleId(roleId);

            return _mapper.Map<List<EmployeeOutputModelForCheckOnAdminRightesByTuid>>(personDTos);
        }

        public List<EmployeeOutputModelForCheckOnAdminRightesByOTP> GetAllPersonsOtpByRoleId(int roleId)
        {
            List<PersonDto> personDTos = _personRepository.GetAllPersonsByRoleId(roleId);

            return _mapper.Map<List<EmployeeOutputModelForCheckOnAdminRightesByOTP>>(personDTos);
        }

        public void AddPersonWithOtp(RegistrationEmployeeByOtpInputModel person)
        {
            _personRepository.AddPerson(_mapper.Map<PersonDto>(person));
        }

        public void AddPersonWithTuid(RegistrationEmployeeByTuidInputModel person)
        {
            _personRepository.AddPerson(_mapper.Map<PersonDto>(person));
        }

        public void AddPerson(RegistrationPersonInputModel person)
        {
            _personRepository.AddPerson(_mapper.Map<PersonDto>(person));
        }

        public List<PersonOutputModel> GetAllPersons()
        {
            List<PersonDto> personDTos = _personRepository.GetAllPersons();

            return _mapper.Map<List<PersonOutputModel>>(personDTos);
        }

        public List<CoachWithSportTypesOutputModel> GetAllCoachesWithSportTypes()
        {
            List<PersonDto> personDTos = _personRepository.GetAllCoachesWithSportTypesWorkoutTypes();

            return _mapper.Map<List<CoachWithSportTypesOutputModel>>(personDTos);
        }

        public PersonOutputModel GetPersonById(int id)
        {
            PersonDto personDTo = _personRepository.GetPersonById(id);

            return _mapper.Map<PersonOutputModel>(personDTo);
        }

        public List<PersonWithTgIdOutputModel> GetPersonsWithTgIdByRoleId(int roleId)
        {
            List<PersonDto> personDTos = _personRepository.GetAllPersonsByRoleId(roleId);

            return _mapper.Map<List<PersonWithTgIdOutputModel>>(personDTos);
        }

        public int GetPassword()
        {
            return new Random().Next(999999);
        }

        public List<AdministratorOutputModel> GetAllAdministrators()
        {
            List<PersonDto> personDTos = _personRepository.GetAllPersonsByRoleId(Constants.AdministratorRoleId);

            return _mapper.Map<List<AdministratorOutputModel>>(personDTos);
        }

        public List<CoachOutputModel> GetAllCoaches()
        {
            List<PersonDto> personDTos = _personRepository.GetAllPersonsByRoleId(2);

            return _mapper.Map<List<CoachOutputModel>>(personDTos);
        }

        public List<CoachOutputModel> GetAllClients()
        {
            List<PersonDto> personDTos = _personRepository.GetAllPersonsByRoleId(3);

            return _mapper.Map<List<CoachOutputModel>>(personDTos);
        }
    }
}