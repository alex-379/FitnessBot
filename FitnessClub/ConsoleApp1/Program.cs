using FitnessClub.BLL;
using FitnessClub.DAL;
using FitnessClub.DAL.Dtos;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using FitnessClub.BLL.Models.TimetableModels.OutputModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FitnessClub.BLL.Models.PersonModels.InputModels;
using FitnessClub.DAL.IRepositories;
using System;

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
//    RoleId = 1,
//    FamilyName = "A",
//    FirstName = "A",
//    Patronymic = "A",
//    PhoneNumber = "A",
//    Email = "A",
//    DateBirth = "A",
//    Sex = false,
//    TelegramUserId = 1,
//    OneTimePassword = 111111
//};

//PersonDto personDto = new()
//{
//    RoleId = 1,
//    OneTimePassword = 111111
//};

//Console.WriteLine(personRepository.AddPerson(personDto));

//personRepository.AddCoachSportType(2, 6);

//personRepository.AddCoachWorkoutType(2, 2);
#endregion

#region GetPerson
//var persons = personRepository.GetAllPersons();

//foreach (var i in persons)
//{
//    Console.WriteLine($"{i.Id} {i.RoleId} {i.FamilyName} {i.FirstName} {i.Patronymic} {i.PhoneNumber} {i.Email} {i.DateBirth} {i.Sex} {i.TelegramUserId} {i.OneTimePassword}");
//}

//var i = personRepository.GetPersonById(2);

//Console.WriteLine($"{i.Id} {i.RoleId} {i.FamilyName} {i.FirstName} {i.Patronymic} {i.PhoneNumber} {i.Email} {i.DateBirth} {i.Sex} {i.TelegramUserId} {i.OneTimePassword}");

//var persons = personRepository.GetAllPersonsByRoleId(2);

//Console.WriteLine();

//var persons = personRepository.GetAllCoachesWithSportTypesWorkoutTypes();

//Console.WriteLine();

//var person = personRepository.GetCoachWithSportTypesWorkoutTypesByCoachId(3);

//Console.WriteLine();
#endregion

#region UpdatePerson
//var i = personRepository.GetPersonById(2);

//i.Patronymic = "Алексеевич";
//i.PhoneNumber = "9993334567";

//personRepository.UpdatePersonOnId(i);
#endregion

#region DeletePerson
//personRepository.DeletePersonById(2);

//personRepository.UndeletePersonById(2);

//personRepository.DeleteOneTimePasswordByPersonId(1);

//personRepository.DeleteCoachSportType(2, 6);

//personRepository.DeleteCoachWorkoutType(2, 2);
#endregion

TimetableRepository timetableRepository = new();

#region AddTimeTable
//TimetableDto timetableDto = new()
//{
//    CoachId = 3,
//    WorkoutId = 2,
//    GymId = 2,
//    Date = "22.03.24",
//    StartTime = "15:00"
//};

//Console.WriteLine(timetableRepository.AddTimetable(timetableDto));

//timetableRepository.AddClientTimetable(5, 10);
#endregion

#region GetTimeTable
//var timetables = timetableRepository.GetAllTimetables();

//foreach (var i in timetables)
//{
//    Console.WriteLine($"{i.Id} {i.Date} {i.StartTime} {i.CoachId} {i.WorkoutId} {i.GymId}");
//}

//var timetables = timetableRepository.GetAllActiveTimetables();

//foreach (var i in timetables)
//{
//    Console.WriteLine($"{i.Id} {i.Date} {i.StartTime} {i.CoachId} {i.WorkoutId} {i.GymId}");
//}

//var timetables = timetableRepository.GetAllArchiveTimetables();

//foreach (var i in timetables)
//{
//    Console.WriteLine($"{i.Id} {i.Date} {i.StartTime} {i.CoachId} {i.WorkoutId} {i.GymId}");
//}

//var i = timetableRepository.GetTimetableById(9);

//Console.WriteLine($"{i.Id} {i.Date} {i.StartTime} {i.CoachId} {i.WorkoutId} {i.GymId}");

//var i = timetableRepository.GetTimetableWithWorkoutById(2);

//Console.WriteLine();

//var i = timetableRepository.GetAllTimetablesWithCoachWorkoutsGymsClients();

//Console.WriteLine();

//var i = timetableRepository.GetTimetableWithCoachWorkoutsGymsClientsById(1);

//Console.WriteLine();
#endregion

#region UpdateTimetable
//var i = timetableRepository.GetTimetableById(9);

//i.CoachId = 4;
//i.GymId = 2;

//timetableRepository.UpdateTimetableOnId(i);
//#endregion

//#region DeleteTimetable
//timetableRepository.DeleteTimetableById(9);

//timetableRepository.UndeleteTimetableById(9);

//timetableRepository.DeleteClientTimetable(5, 10);
#endregion


WorkoutRepository workoutRepository = new();

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

//Console.WriteLine(workoutRepository.AddWorkout(workoutDto));
#endregion

#region GetWorkout
//var workouts = workoutRepository.GetAllWorkouts();

//foreach (var i in workouts)
//{
//    Console.WriteLine($"{i.Id} {i.SportTypeId} {i.Price} {i.Duration} {i.NumberPlaces} {i.IsGroup} {i.Comment} ");
//}

//var i = workoutRepository.GetWorkoutById(1);

//Console.WriteLine($"{i.Id} {i.SportTypeId} {i.Price} {i.Duration} {i.NumberPlaces} {i.IsGroup} {i.Comment}");

//var i = workoutRepository.GetAllWorkoutsWithSportType();

//Console.WriteLine();

//var i = workoutRepository.GetWorkoutWithSportTypeById(2);

//Console.WriteLine();

//var i = workoutRepository.GetAllWorkoutsWithSportTypeBySportTypeId(6);

//Console.WriteLine();
#endregion

#region UpdateWorkout
//var i = workoutRepository.GetWorkoutById(2);

//i.SportTypeId = 4;
//i.Price = 1500;

//workoutRepository.UpdateWorkoutOnId(i);
//#endregion

//#region DeleteWorkout
//workoutRepository.DeleteWorkoutById(3);

//workoutRepository.UndeleteWorkoutById(3);
//#endregion

//SportTypeClient sportTypeClient = new();

//#region SportTypeOutputModels
//var sportTypes = sportTypeClient.GetAllSportTypes();

//Console.WriteLine();
#endregion

PersonClient personClient = new();

#region PersonInputModels
RegistrationEmployeeByOtpInputModel person = new()
{
    RoleId = 1,
    OneTimePassword = 932526
};

personClient.AddPersonWithOtp(person);
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


//PersonClient personClient = new();
//var coaches = personClient.GetCoachesWithTgIdByRoleId(2);
//Console.WriteLine();

//string sportType = "Волейбол";
//int workoutType;
//string date = "21.03.24";


//TimetableClient timetableClient = new();
//var timetables = timetableClient.GetAllTimetablesWithCoachWorkoutsGymsClients();
//Console.WriteLine();
//TimetableClient timetableClient = new();
//List<GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel> dates = timetableClient.GetAllTimetablesWithCoachWorkoutsGymsClients();
//var filteredResults = from GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel in dates
//                      where GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.SportType.SportType == sportType &
//                      GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel.Workout.IsGroup == workoutType
//                      select GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel;
#endregion