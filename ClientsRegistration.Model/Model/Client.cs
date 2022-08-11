using ClientsRegistration.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace ClientsRegistration.Model.Model
{
    public class Client
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string EnterpriseName { get; set; }
        [MaxLength(11)]
        public string Cpf { get; set; }
        [MaxLength(14)]
        public string Cnpj { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(30)]
        public List<PhoneNumber> PhoneNumbers { get; set; } = new();
        public Address Address { get; set; } = new();
        public ClassificationEnum Classification { get; set; }
        public ClientTypeEnum ClientType { get; set; }
    }
}
