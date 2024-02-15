using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessClub.DAL.Dtos;
using FitnessClub.BLL.Models.TimetableModels.OutputModels;
using FitnessClub.BLL.Models.TimetableModels.InputModels;

namespace FitnessClub.BLL.Mapping
{
    public class TimetableMappingProfile: Profile
    {
        public TimetableMappingProfile()
        {
            CreateMap<TimetableDto, GetTimetablesOutputModel>();
            CreateMap<AddClientTimetableInputModel, TimetableDto>();
            CreateMap<AddTimetableInputModel, TimetableDto>();
            CreateMap<TimetableDto, GetAllTimetablesWithCoachWorkoutsGymsClientsOutputModel>();
        }
    }
}
