using AutoMapper;
using FitnessClub.BLL.Mapping;
using FitnessClub.DAL;
using FitnessClub.DAL.IRepositories;

namespace FitnessClub.BLL
{
    public class WorkoutClient
    {
        private IWorkoutRepository _workoutRepository;
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