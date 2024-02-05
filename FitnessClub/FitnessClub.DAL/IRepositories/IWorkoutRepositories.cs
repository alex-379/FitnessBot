using FitnessClub.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FitnessClub.DAL.IRepositories
{
    public interface IWorkoutRepositories
    {
        public void AddWorkots (WorkoutDTO workout);
        public void DeleteWorkoutsById (WorkoutDTO workout);
        public void UpdateWorkoutsById(List<WorkoutDTO> workouts);

        public List<WorkoutDTO> GetAllWorkots ();
        public List<WorkoutDTO> GetWorkoutsById ();

    }
}
