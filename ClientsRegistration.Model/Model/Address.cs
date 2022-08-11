using System.ComponentModel.DataAnnotations;

namespace ClientsRegistration.Model.Model
{
    public class Address
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [MaxLength(8)]
        public string? PostalCode { get; set; }
        [MaxLength(100)]
        public string? Street { get; set; }
        [MaxLength(100)]
        public string? Neighborhood { get; set; }
        [MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(2)]
        public string? State { get; set; }
        public int Number { get; set; }
        [MaxLength(30)]
        public string? Complement { get; set; }
        public Client Client { get; set; }
    }
}
