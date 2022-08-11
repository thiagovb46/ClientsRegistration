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
        public int Id { get; set; }
        [JsonPropertyName("tipoCliente")]
        public ClientTypeEnum ClientType { get; set; }
        [ReqWhen(nameof(ClientType), ClientTypeEnum.juridica)]
        public string? Cnpj { get; set; }
        [ReqWhen(nameof(ClientType), ClientTypeEnum.fisica)]
        public string? CPF { get; set; }
        [ReqWhen(nameof(ClientType), ClientTypeEnum.fisica)]
        [JsonPropertyName("nome")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Phone]
        [JsonPropertyName("telefones")]
        public List<PhoneNumberDto> Phones { get; set; }
        [MaxLength(100, ErrorMessage = "Campo {0} deve ter no máximo 100 caracteres")]
        [ReqWhen(nameof(ClientType), ClientTypeEnum.juridica)]
        //[JsonPropertyName("razaoSocial")]
        public string? EnterpriseName { get; set; }
        public AddressDto Address { get; set; }
        public string? PostalCode { get; set; }
        [JsonPropertyName("classificacao")]
        public ClassificationEnum Classification { get; set; }
        public ClientResponseDto GetExamples()
        {
            return new()
            {
                Id = 1,
                ClientType = ClientTypeEnum.fisica,
                CPF = "16876931021",
                Name = "Joao Silveira",
                Email = "joaoj@gmail.com",
                Phones = new PhoneNumberDto().GetExample(),
                Address = new AddressDto().GetExample(),
                Classification = ClassificationEnum.Active,
            };
        }

    }
}
