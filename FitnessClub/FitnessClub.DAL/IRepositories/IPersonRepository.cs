using FitnessClub.DAL.Dtos;

namespace FitnessClub.DAL.IRepositories
{
    public interface IPersonRepository
    {
        public void AddPerson(PersonDto person);

        public List<PersonDto> GetAllPersons();

        public PersonDto GetPersonById(int id);
    }
}
