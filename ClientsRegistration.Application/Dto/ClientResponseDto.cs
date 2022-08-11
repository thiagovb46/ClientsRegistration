using ClientsRegistration.Application.Validations;
using ClientsRegistration.Model.Enum;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientsRegistration.Application.Dto
{
    public class ClientResponseDto
    {
        [Required(ErrorMessage = "Informe o id do cliente")]
        public int id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientTypeEnum ClientType { get; set; }
        [RequiredWhen(nameof(ClientType), ClientTypeEnum.juridica)]
        [MaxLength(14, ErrorMessage = "Campo {0} deve ter 14 caracteres e não deve ter caracteres especiais")]
        [MinLength(14, ErrorMessage = "Campo {0}  deve ter 14 caracteres e não deve ter caracteres especiais")]
        public string Cnpj { get; set; }
        [RequiredWhen(nameof(ClientType), ClientTypeEnum.fisica)]
        [MaxLength(11, ErrorMessage = "Campo {0} deve ter 11 caracteres e não deve ter caracteres especiais")]
        [MinLength(11, ErrorMessage = "Campo {0}  deve ter 11 caracteres e não deve ter caracteres especiais")]
        public string CPF { get; set; }
        [RequiredWhen(nameof(ClientType), ClientTypeEnum.fisica)]
        [JsonPropertyName("nome")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        [JsonPropertyName("telefones")]
        public List<PhoneNumberDto> Phones { get; set; }
        [MaxLength(100, ErrorMessage = "Campo {0} deve ter no máximo 100 caracteres")]
        [RequiredWhen(nameof(ClientType), ClientTypeEnum.juridica)]
        [JsonPropertyName("razaoSocial")]
        public string EnterpriseName { get; set; }
        public AddressDto Address { get; set; }
        public string PostalCode { get; set; }
        [JsonPropertyName("classificacao")]
        public ClassificationEnum Classification { get; set; }


    }
}
