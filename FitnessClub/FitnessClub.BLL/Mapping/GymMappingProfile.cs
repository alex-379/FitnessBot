using AutoMapper;
using FitnessClub.BLL.Models.GymModels;
using FitnessClub.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.BLL.Mapping
{
    public class GymMappingProfile : Profile
    {
        public GymMappingProfile()
        {
            CreateMap<GymDto, GymOutputModel>();
        }
    }
}
