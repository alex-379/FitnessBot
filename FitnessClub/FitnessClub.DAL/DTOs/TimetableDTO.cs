using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.DAL.DTOs
{
    public class TimetableDTO
    {
        public int? Id { get; set; }
        public string DateTime { get; set; }
        public int CoachId { get; set; }
        public int WorkoutId {  get; set; }
        public int GymId { get; set; }
        public WorkoutDTO Workout { get; set; }
        public int? ClientId { get; set;}
        public int? TimetableId { get; set;}

    }
}
