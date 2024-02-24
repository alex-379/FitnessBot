using FitnessClub.DAL.Dtos;

namespace FitnessClub.BLL.Models.PersonModels.OutputModels
{
    public class EmployeeOutputModelForCheckOnAdminRightesByOTP
    {
        public RoleDto Role { get; set; }

        public int OneTimePassword { get; set; }
    }
}