using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.InputModels;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL;

namespace FitnessClub.TG.Handlers.MessageHandlers
{
    public class PersonHandler
    {
        PersonClient personClient = new();

        public List<EmployeeModelForCheckOnAdminRightesByOtp> GetAllPersonsOtpByRoleId(int roleId)
        {
            List<EmployeeModelForCheckOnAdminRightesByOtp> persons = personClient.GetAllPersonsOtpByRoleId(roleId);

            return persons;
        }
    }
}