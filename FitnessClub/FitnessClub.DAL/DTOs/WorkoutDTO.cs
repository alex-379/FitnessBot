using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.DAL.DTOs
{
    public class WorkoutDTO
    {
        public int? Id { get; set; }
        public int? SportTypeId { get; set; }
        public int? Price { get; set; }
        public int? Duration { get; set; }
        public int? NumberPlaces { get; set; }
        public int? Comment { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
