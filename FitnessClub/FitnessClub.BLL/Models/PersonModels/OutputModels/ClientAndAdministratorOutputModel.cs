﻿namespace FitnessClub.BLL.Models.PersonModels.OutputModels
{
    public class ClientAndAdministratorOutputModel
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string? FamilyName { get; set; }

        public string? FirstName { get; set; }
    }
}
