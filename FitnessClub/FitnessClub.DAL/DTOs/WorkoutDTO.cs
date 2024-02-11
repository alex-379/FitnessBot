namespace FitnessClub.DAL.Dtos
{
    public class WorkoutDto
    {
        public int? Id { get; set; }

        public int? SportTypeId { get; set; }

        public decimal? Price { get; set; }

        public int? Duration { get; set; }

        public int? NumberPlaces { get; set; }

        public bool? IsGroup { get; set; }

        public string? Comment { get; set; }

        public bool? IsDeleted { get; set; }

        public int? WorkoutId { get; set; }
    }
}
