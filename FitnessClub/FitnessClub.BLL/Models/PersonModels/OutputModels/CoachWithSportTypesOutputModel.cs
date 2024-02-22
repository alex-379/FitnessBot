using FitnessClub.BLL.Models.SportTypeModels;

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
