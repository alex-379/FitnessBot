using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.BLL.Models.TimetableModels.InputModels
{
    public class AddTimetableInputModel
    {
        public string DateTime { get; set; }
        public int CoachId { get; set; }
        public int WorkoutId { get; set; }
        public int GymId { get; set; }
    }
}
