using FitnessClub.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.DAL.IRepositories
{
    public interface IPersonRepository
    {
        public void AddPerson(PersonDTO person);


        public List<PersonDTO> GetAllPersons();
        public PersonDTO GetPersonById(int id);
    }
}
