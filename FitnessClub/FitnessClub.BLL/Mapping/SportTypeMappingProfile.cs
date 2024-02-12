using AutoMapper;
using FitnessClub.BLL.Models.SportTypeModels;
using FitnessClub.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.BLL.Mapping
{
    public class SportTypeMappingProfile: Profile
    {
        public SportTypeMappingProfile()
        {
            CreateMap<SportTypeDto, SportTypeOutputModel>();
        }
    }
}
