using ClientsRegistration.Application.Validations;
using ClientsRegistration.Model.Enum;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientsRegistration.Application.Dto
{
    public class ClientRequestDto
    {
        #region Properties
        [Required]
        //[JsonConverter(typeof(StringEnumConverter))]
        [JsonPropertyName("tipoCliente")]
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
        [JsonPropertyName("telefones")]
        public List<PhoneNumberDto> Phones { get; set; }
        [MaxLength(100, ErrorMessage = "Campo {0} deve ter no máximo 100 caracteres")]
        [RequiredWhen(nameof(ClientType), ClientTypeEnum.juridica)]
        [JsonPropertyName("razaoSocial")]
        public string EnterpriseName { get; set; }
        [JsonPropertyName("endereco")]
        public AddressDto Address { get; set; }
        [JsonPropertyName("classificacao")]
        public ClassificationEnum Classification { get; set; }
        #endregion
        #region Swagger Examples Generator
        public ClientRequestDto GetExamples()
        {
            return new()
            {
                ClientType = ClientTypeEnum.fisica,
                CPF = "16876931021",
                Name = "Joao Silveira",
                Email = "joaoj@gmail.com",
                Phones = new PhoneNumberDto().GetExample(),
                Address = new AddressDto().GetExample(),
                Classification = ClassificationEnum.Active,
            };
        }
        #endregion


    }
}
