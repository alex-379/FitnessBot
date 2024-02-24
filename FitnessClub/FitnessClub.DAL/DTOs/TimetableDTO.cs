﻿namespace FitnessClub.DAL.Dtos
{
    public class TimetableDto
    {
        public int? Id { get; set; }

        public int? CoachId { get; set; }

        public int? WorkoutId { get; set; }

        public int? GymId { get; set; }

        public string? Date { get; set; }

        public string? StartTime { get; set; }

        public PersonDto Client { get; set; }

        public PersonDto Coach { get; set; }

        public WorkoutDto Workout { get; set; }

        public GymDto Gym { get; set; }

        public SportTypeDto SportType { get; set; }

        public WorkoutTypeDto WorkoutType {  get; set; }
    }
}