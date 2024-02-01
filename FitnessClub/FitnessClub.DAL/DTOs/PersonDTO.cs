﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.DAL.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string? FamilyName { get; set; }

        public string? FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? DateBirth { get; set; }

        public bool? Sex { get; set; }

        public int IsDeleted { get; set; }
    }
}
