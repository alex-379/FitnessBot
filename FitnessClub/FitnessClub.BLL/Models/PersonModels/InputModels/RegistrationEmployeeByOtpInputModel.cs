using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Models.PersonModels.InputModels
{
    public class RegistrationEmployeeByOtpInputModel
    {
        public int RoleId { get; set; }

        public int OneTimePassword { get; set; }
        }
}