using AutoMapper;
using FitnessClub.BLL.Models.TimetableModels.InputModels;
using FitnessClub.BLL.Models.TimetableModels.OutputModels;
using FitnessClub.DAL.Dtos;
using FitnessClub.DAL.IRepositories;
using FitnessClub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessClub.BLL.Mapping;

namespace FitnessClub.BLL
{
    public class TimetableClient
    {
        private ITimetableRepository _timetableRepository;
        private Mapper _mapper;

        public TimetableClient()
        {
            _timetableRepository = new TimetableRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TimetableMappingProfile());
                cfg.AddProfile(new PersonMappingProfile());
                cfg.AddProfile(new WorkoutMappingProfile());
                cfg.AddProfile(new SportTypeMappingProfile());
                cfg.AddProfile(new GymMappingProfile());
            });
            _mapper = new Mapper(config);
        }
        public void AddTimetable(AddTimetableInputModel timetable)
        {

        }

        public void AddClientTimetable(AddClientTimetableInputModel clientTimetable)
        {

        }

        public List<TimetableOutputModel> GetAllTimetables()
        {
            List<TimetableDto> timetableDtos = _timetableRepository.GetAllTimetables();
            return _mapper.Map<List<TimetableOutputModel>>(timetableDtos);

        }
        public TimetableOutputModel GetTimetableById(int id)
        {
            TimetableDto timetableDtos = _timetableRepository.GetTimetableById(id);
            return _mapper.Map<TimetableOutputModel>(timetableDtos);
        }

        public List<GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel> GetAllTimetablesWithCoachWorkoutsGymsClients()
        {
            List<TimetableDto> timetableDtos = _timetableRepository.GetAllTimetablesWithCoachWorkoutsGymsClients();
            return _mapper.Map<List<GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel>>(timetableDtos);

        }

        public List<TimetableOutputModel> GetTimetableDates()
        {
            List<TimetableDto> timetableDtos = _timetableRepository.GetAllTimetables();
            return _mapper.Map<List<TimetableOutputModel>>(timetableDtos);

        }

    }
}
