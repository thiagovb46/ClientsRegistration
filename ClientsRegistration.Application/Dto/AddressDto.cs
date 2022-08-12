using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientsRegistration.Application.Dto
{
    public class AddressDto
    {
        #region Properties
        [JsonPropertyName("cep")]
        [Required]
        [MaxLength(8, ErrorMessage = "Formato de Cep Invalido, envie sem caracteres especiais")]
        public string PostalCode { get; set; }
        [Required]
        [JsonPropertyName("logradouro")]
        public string Street { get; set; }
        [JsonPropertyName("bairro")]
        [Required]
        public string Neighborhood { get; set; }
        [JsonPropertyName("cidade")]
        [Required]
        public string City { get; set; }
        [JsonPropertyName("estado")]
        [Required]
        [MaxLength(2)]
        public string State { get; set; }
        [JsonPropertyName("numero")]
        public int Number { get; set; }
        public string Complement { get; set; }
        #endregion
        #region SwaggerExamples
        public AddressDto GetExample()
        {
            return new()
            {
                PostalCode = "38408210",
                Street = "Rua Antônio Fortunato da Silva",
                Number = 3333,
                Neighborhood = "Santa Mônica",
                State = "MG",
                Complement = "apto 405",
                City = "Uberlândia",
            };
        }
        #endregion
    }
}
