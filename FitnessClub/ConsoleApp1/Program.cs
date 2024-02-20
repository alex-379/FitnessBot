using FitnessClub.BLL;
using FitnessClub.DAL;
using FitnessClub.DAL.Dtos;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

GymRepository gymRepository = new();

#region GetGyms
//var gyms = gymRepository.GetAllGyms();

//foreach (var i in gyms)
//{
//    Console.WriteLine($"{i.GymId} {i.Gym}");
//}

#endregion

SportTypeRepository SportTypeRepository = new();

#region GetSportTypes
//var sportTypes = SportTypeRepository.GetAllSportTypes();

//foreach (var i in sportTypes)
//{
//    Console.WriteLine($"{i.SportTypeId} {i.SportType}");
//}

#endregion


PersonRepository personRepository = new();

#region AddPerson
//PersonDto personDto = new()
//{
//    RoleId = 2,
//    FamilyName = "Стрельникова",
//    FirstName = "Мария",
//    Patronymic = "",
//    PhoneNumber = "",
//    Email = "strelnikova@mail.ru",
//    DateBirth = "12.10.1972",
//    Sex = false
//};

//Console.WriteLine(personRepository.AddPerson(personDto));

//personRepository.AddCoachSportType(3, 4);

//personRepository.AddCoachWorkoutType(2, 2);
#endregion

#region GetPerson
//var persons = personRepository.GetAllPersons();

//foreach (var i in persons)
//{
//    Console.WriteLine($"{i.Id} {i.RoleId} {i.FamilyName} {i.FirstName} {i.Patronymic} {i.PhoneNumber} {i.Email} {i.DateBirth} {i.Sex}");
//}

//var i = personRepository.GetPersonById(21);

//Console.WriteLine($"{i.Id} {i.RoleId} {i.FamilyName} {i.FirstName} {i.Patronymic} {i.PhoneNumber} {i.Email} {i.DateBirth} {i.Sex}");

//var persons = personRepository.GetAllPersonsByRoleId(2);

//Console.WriteLine();

//var persons = personRepository.GetAllCoachesWithSportTypesWorkoutTypes();

//Console.WriteLine();

//var person = personRepository.GetCoachWithSportTypesWorkoutTypesById(12);

//Console.WriteLine();

#endregion

#region UpdatePerson
//var i = personRepository.GetPersonById(11);

//i.Patronymic = "Алексеевна";
//i.PhoneNumber = "+77777777777";

//personRepository.UpdatePersonOnId(i);
#endregion

#region DeletePerson
//var i = personRepository.GetPersonById(20);

//personRepository.DeletePersonOnId(i);

//personRepository.DeleteCoachSportType(6,6);

//personRepository.DeleteCoachWorkoutType(5,1);
#endregion


TimetableRepository timetableRepository = new();

#region AddTimeTable
//TimetableDto timetableDto = new()
//{
//    DateTime = "21.03.24",
//    CoachId = 3,
//    WorkoutId = 1,
//    GymId = 1
//};

//Console.WriteLine(timetableRepository.AddTimetable(timetableDto));

//timetableRepository.AddClientTimetable(17, 1);
#endregion

#region GetTimeTable
//var timetables = timetableRepository.GetAllTimetables();

//foreach (var i in timetables)
//{
//    Console.WriteLine($"{i.Id} {i.DateTime} {i.CoachId} {i.WorkoutId} {i.GymId}");
//}

//var i = timetableRepository.GetTimetableById(2);

//Console.WriteLine($"{i.Id} {i.DateTime} {i.CoachId} {i.WorkoutId} {i.GymId}");

//var i = timetableRepository.GetTimetableWithWorkoutById(2);

//Console.WriteLine();

//var i = timetableRepository.GetAllTimetablesWithCoachWorkoutsGymsClients();

//Console.WriteLine();

//var i = timetableRepository.GetTimetableWithCoachWorkoutsGymsClientsById(1);

//Console.WriteLine();
#endregion

#region UpdateTimetable
//var i = timetableRepository.GetTimetableById(2);

//i.CoachId = 3;
//i.GymId = 1;

//timetableRepository.UpdateTimetableOnId(i);
#endregion

#region DeleteTimetable
//var i = timetableRepository.GetTimetableById(1);

//timetableRepository.DeleteTimetableOnId(i);

//timetableRepository.DeleteClientTimetable(7,1);
#endregion


WorkoutRepository workoutRepositiry = new();

#region AddWorkout
//WorkoutDto workoutDto = new()
//{
//    SportTypeId = 1,
//    Price = 500,
//    Duration = 120,
//    NumberPlaces = 10,
//    IsGroup = true,
//    Comment = ""
//};

//Console.WriteLine(workoutRepositiry.AddWorkout(workoutDto));
#endregion

#region GetWorkout
//var workouts = workoutRepositiry.GetAllWorkouts();

//foreach (var i in workouts)
//{
//    Console.WriteLine($"{i.Id} {i.SportTypeId} {i.Price} {i.Duration} {i.NumberPlaces} {i.IsGroup} {i.Comment} ");
//}

//var i = workoutRepositiry.GetWorkoutById(1);

//Console.WriteLine($"{i.Id} {i.SportTypeId} {i.Price} {i.Duration} {i.NumberPlaces} {i.IsGroup} {i.Comment}");

//var i = workoutRepositiry.GetAllWorkoutsWithSportType();

//Console.WriteLine();

//var i = workoutRepositiry.GetWorkoutWithSportTypeById(2);

//Console.WriteLine();

//var i = workoutRepositiry.GetWorkoutsWithSportTypeBySportTypeId(1);

//Console.WriteLine();
#endregion

#region UpdateWorkout
//var i = workoutRepositiry.GetWorkoutById(2);

//i.SportTypeId = 3;
//i.Price = 1000;

//workoutRepositiry.UpdateWorkoutOnId(i);
#endregion

#region DeleteWorkout
//var i = workoutRepositiry.GetWorkoutById(3);

//workoutRepositiry.DeleteWorkoutOnId(i);
#endregion

SportTypeClient sportTypeClient = new();

#region SportTypeOutputModels
//var sportTypes = sportTypeClient.GetAllSportTypes();

//Console.WriteLine();
#endregion

PersonClient personClient = new();

#region PersonInputModels

#endregion

#region PersonOutputModels
//var persons = personClient.GetAllPersons();

//Console.WriteLine();

//var persons = personClient.GetAllCoachesWithSportTypes();

//Console.WriteLine();

//var person = personClient.GetPersonById(2);

//Console.WriteLine();
#endregion

TimetableClient timetableClient = new();

#region TimetableOutputModels
//var timetables = timetableClient.GetAllTimetablesWithCoachWorkoutsGymsClients();



//Console.WriteLine();

#endregion