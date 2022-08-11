using ClientsRegistration.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientsRegistration.Application.Dto
{
    public class ClientUpdateRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        [JsonPropertyName("telefones")]
        public List<PhoneNumberDto> PhoneNumbers { get; set; }
        [MaxLength(100, ErrorMessage = "Campo {0} deve ter no máximo 100 caracteres")]
        public AddressDto Address { get; set; }
        [JsonPropertyName("classificacao")]
        public ClassificationEnum Classification { get; set; }
    }
}
