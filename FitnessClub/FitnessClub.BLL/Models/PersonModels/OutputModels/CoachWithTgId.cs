using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.BLL.Models.PersonModels.OutputModels
{
    public class CoachWithTgId
    {
        public int Id { get; set; }

        public long? TelegramUserId { get; set; }
    }
}
