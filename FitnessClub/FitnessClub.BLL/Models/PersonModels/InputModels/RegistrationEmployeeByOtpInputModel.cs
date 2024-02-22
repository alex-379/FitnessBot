namespace FitnessClub.BLL.Models.PersonModels.InputModels
{
    public class RegistrationEmployeeByOtpInputModel
    {
        public int RoleId { get; set; }

        public long OneTimePassword { get; set; }
    }
}