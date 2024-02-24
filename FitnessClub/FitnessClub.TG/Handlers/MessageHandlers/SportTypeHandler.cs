using FitnessClub.BLL;
using FitnessClub.BLL.Models.PersonModels.OutputModels;
using FitnessClub.BLL.Models.SportTypeModels;

namespace FitnessClub.TG.Handlers.MessageHandlers
{
    public class SportTypeHandler
    {
        public List<SportTypeNameOutputModel> GetAllSportTypesNames()
        {
            SportTypeClient sportTypeClient = new();
            List<SportTypeNameOutputModel> sportTypes = sportTypeClient.GetAllSportTypesNames();

            return sportTypes;
        }
    }
}