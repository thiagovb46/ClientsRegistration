using ClientsRegistration.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientsRegistration.Application.Dto
{
    public class ClientUpdateRequestDto
    {
        #region Properties
        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [JsonPropertyName("telefones")]
        public List<PhoneNumberDto> Phones { get; set; }
        [MaxLength(100, ErrorMessage = "Campo {0} deve ter no máximo 100 caracteres")]
        [JsonPropertyName("endereco")]
        public AddressDto Address { get; set; }
        [JsonPropertyName("classificacao")]
        public ClassificationEnum Classification { get; set; }
        #endregion

        #region Swagger Examples
        public ClientUpdateRequestDto GetExamples()
        {
            return new()
            {
                Email = "joaoj@gmail.com",
                Phones = new PhoneNumberDto().GetExample(),
                Address = new AddressDto().GetExample(),
                Classification = ClassificationEnum.Preferential,
            };
        }
        #endregion
    }
}
