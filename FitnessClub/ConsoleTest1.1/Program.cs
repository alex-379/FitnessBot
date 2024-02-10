using FitnessClub.DAL;

WorkoutRepository workRepository  = new WorkoutRepository();

var w = workRepository.GetAllWorkouts();

Console.WriteLine();