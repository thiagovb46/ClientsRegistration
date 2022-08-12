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
        [JsonPropertyName("telefones")]
        public List<PhoneNumberDto> Phones { get; set; }
        [JsonPropertyName("endereco")]
        [Required]
        public AddressDto Address { get; set; }
        [JsonPropertyName("classificacao")]
        [Required]
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
