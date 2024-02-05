using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.DAL.StoredProcedures
{
    public class WorkoutStoredProcedures
    {
        public const string AddWorkouts = "AddWorkouts";
        public const string DeleteWorkoutsById = "DeleteWorkoutsById";
        public const string UpdateWorkoutsById = "UpdateWorkoutsById";
        public const string GetAllWorkouts = "GetAllWorkouts";
        public const string GetWorkoutsById = "GetWorkoutsById";
    }
}
