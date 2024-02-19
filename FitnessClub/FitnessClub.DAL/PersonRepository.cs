using Dapper;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.IRepositories;
using FitnessClub.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClub.DAL
{
    public class PersonRepository : IPersonRepository
    {
        public int? AddEmployee(PersonDto person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.QuerySingle<int>(PersonStoredProcedures.AddEmployee,
                    new { person.RoleId, person.FamilyName, person.FirstName, person.Patronymic, person.PhoneNumber, person.Email, person.DateBirth, person.Sex, person.TelegramUserId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddCoachSportType(int coachId, int sportTypeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<int>(PersonStoredProcedures.AddCoachSportType,
                    new { coachId, sportTypeId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddCoachWorkoutType(int coachId, int workoutTypeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<int>(PersonStoredProcedures.AddCoachWorkoutType,
                    new { coachId, workoutTypeId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<PersonDto> GetAllPersons()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<PersonDto>(PersonStoredProcedures.GetAllPersons,
                commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public PersonDto GetPersonById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.QuerySingle<PersonDto>(PersonStoredProcedures.GetPersonById,
                new { id },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdatePersonOnId(PersonDto person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<PersonDto>(PersonStoredProcedures.UpdatePersonOnId,
                    new { person.Id, person.RoleId, person.FamilyName, person.FirstName, person.Patronymic, person.PhoneNumber, person.Email, person.DateBirth, person.Sex },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeletePersonOnId(PersonDto person)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<PersonDto>(PersonStoredProcedures.DeletePersonOnId,
                    new { person.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCoachSportType(int coachId, int sportTypeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<int>(PersonStoredProcedures.DeleteCoachSportType, new { coachId, sportTypeId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCoachWorkoutType(int coachId, int workoutTypeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                connection.Query<int>(PersonStoredProcedures.DeleteCoachWorkoutType, new { coachId, workoutTypeId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<PersonDto> GetAllPersonsByRoleId(int roleId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                return connection.Query<PersonDto, RoleDto, PersonDto>(PersonStoredProcedures.GetAllPersonsByRoleId,
                    (person, role) =>
                    {
                        person.Role = role;
                        return person;
                    },
                    new { roleId },
                    splitOn: "RoleId",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<PersonDto> GetAllCoachesWithSportTypesWorkoutTypes()
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                const int roleId = 2;

                Dictionary<int, PersonDto> coaches = new();

                connection.Query<PersonDto, SportTypeDto, WorkoutTypeDto, PersonDto>(PersonStoredProcedures.GetAllCoachesWithSportTypesWorkoutTypes,
                        (coach, sportType, workoutType) =>
                        {
                            if (!coaches.ContainsKey((int)coach.Id))
                            {
                                coaches.Add((int)coach.Id, coach);
                            }

                            PersonDto crntCoach = coaches[(int)coach.Id];

                            crntCoach.SportTypes.Add(sportType);

                            crntCoach.WorkoutTypes.Add(workoutType);

                            return crntCoach;
                        },
                        new { roleId },
                        splitOn: "SportTypeId,WorkoutTypeId",
                        commandType: CommandType.StoredProcedure);


                return coaches.Values.ToList();
            }
        }

        public PersonDto GetCoachWithSportTypesWorkoutTypesById(int coachId)
        {
            using (IDbConnection connection = new SqlConnection(Options.connectionString))
            {
                const int roleId = 2;

                PersonDto crntCoach = null;

                connection.Query<PersonDto, SportTypeDto, WorkoutTypeDto, PersonDto>(PersonStoredProcedures.GetCoachWithSportTypesWorkoutTypesById,
                        (coach, sportType, workoutType) =>
                        {
                            if (crntCoach == null)
                            {
                                crntCoach = coach;
                            }

                            crntCoach.SportTypes.Add(sportType);

                            crntCoach.WorkoutTypes.Add(workoutType);

                            return crntCoach;
                        },
                        new { roleId, coachId },
                        splitOn: "SportTypeId,WorkoutTypeId",
                        commandType: CommandType.StoredProcedure);


                return crntCoach;
            }
        }
    }
}