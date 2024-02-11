using AutoMapper;
using FitnessClub.BLL.Mapping;
using FitnessClub.DAL;
using FitnessClub.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.BLL
{
    public class WorkoutClient
    {
        private IWorkoutRepositories _workoutRepository;
        private Mapper _mapper;

        public WorkoutClient()
        {
            _workoutRepository = new WorkoutRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PersonMappingProfile());
            });

            _mapper = new Mapper(config);
        }
    }
}
