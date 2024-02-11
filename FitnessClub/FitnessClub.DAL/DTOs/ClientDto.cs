namespace FitnessClub.DAL.Dtos
{
    public class ClientDto
    {
        public int? ClientId { get; set; }

        public string? ClientFamilyName { get; set; }

        public string? ClientFirstName { get; set; }

        public string? ClientPatronymic { get; set; }

        public string? ClientPhoneNumber { get; set; }

        public string? ClientEmail { get; set; }

        public string? ClientDateBirth { get; set; }

        public bool? ClientSex { get; set; }
    }
}