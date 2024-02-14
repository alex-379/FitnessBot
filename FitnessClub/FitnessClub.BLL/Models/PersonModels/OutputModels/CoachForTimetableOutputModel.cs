﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.BLL.Models.PersonModels.OutputModels
{
    public class CoachForTimetableOutputModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string DateBirth { get; set; }

        public bool Sex { get; set; }
    }
}
