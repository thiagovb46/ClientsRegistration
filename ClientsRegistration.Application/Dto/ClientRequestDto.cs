using ClientsRegistration.Application.Validations;
using ClientsRegistration.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientsRegistration.Application.Dto
{
    public class ClientRequestDto
    {
        #region Properties

        [JsonPropertyName("tipoCliente")]
        [Required]
        public ClientTypeEnum ClientType { get; set; }
        [ReqWhen(nameof(ClientType), ClientTypeEnum.juridica)]
        [ValidCNPJ]
        public string? Cnpj { get; set; }
        [ReqWhen(nameof(ClientType), ClientTypeEnum.fisica)]
        [ValidCPF]
        public string? CPF { get; set; }
        [ReqWhen(nameof(ClientType), ClientTypeEnum.fisica)]
        [JsonPropertyName("nome")]
        [MaxLength(100, ErrorMessage = "Campo {0} deve ter no máximo 100 caracteres")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [JsonPropertyName("telefones")]
        public List<PhoneNumberDto> Phones { get; set; }
        [MaxLength(100, ErrorMessage = "Campo {0} deve ter no máximo 100 caracteres")]
        [ReqWhen(nameof(ClientType), ClientTypeEnum.juridica)]
        [JsonPropertyName("razaoSocial")]
        public string? EnterpriseName { get; set; }
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
