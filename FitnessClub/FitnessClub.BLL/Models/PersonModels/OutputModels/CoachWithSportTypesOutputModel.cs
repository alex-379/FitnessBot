using FitnessClub.BLL.Models.SportTypeModels;
using FitnessClub.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.BLL.Models.PersonModels.OutputModels
{
    public class CoachWithSportTypesOutputModel
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string? FullName { get; set; }

        public List<SportTypeOutputModel> SportTypes { get; set; }
    }
}
