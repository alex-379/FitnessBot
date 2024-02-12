using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Models.PersonModels.InputModels
{
    public class CoachInputModel
    {
        public CoachInputModel()
        {
            //SportTypes = new List<SportTypeModel>();

            //WorkoutTypes = new List<WorkoutTypeModel>();
        }
        public string? FamilyName { get; set; }

        public string? FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? DateBirth { get; set; }

        public bool? Sex { get; set; }

//        public List<SportTypeModel> SportTypes { get; set; }

 //       public List<WorkoutTypeModel> WorkoutTypes { get; set; }
    }
}
