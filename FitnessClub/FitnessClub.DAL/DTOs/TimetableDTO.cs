﻿namespace FitnessClub.DAL.Dtos
{
    public class TimetableDto
    {
        public TimetableDto()
        {
            Clients = new List<PersonDto>();
        }

        public int? Id { get; set; }

        public string? DateTime { get; set; }

        public int? CoachId { get; set; }

        public int? WorkoutId { get; set; }

        public int? GymId { get; set; }

        public List<PersonDto> Clients { get; set; }

        public PersonDto Coach { get; set; }

        public WorkoutDto Workout { get; set; }

        public GymDto Gym { get; set; }

        public SportTypeDto SportType { get; set; }
    }
}