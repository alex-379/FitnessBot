using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.BLL.Models.TimetableModels.OutputModels
{
    public class GetTimetablesOutputModel
    {
        public int Id { get; set; }

        public string? DateTime { get; set; }

        public int CoachId { get; set; }

        public int WorkoutId { get; set; }

        public int GymId { get; set; }
    }
}
