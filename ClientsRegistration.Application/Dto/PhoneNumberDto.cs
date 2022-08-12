using System.ComponentModel.DataAnnotations;

namespace ClientsRegistration.Application.Dto
{
    public class PhoneNumberDto
    {
        [Range(10, 99, ErrorMessage = "Digite um dd válido")]
        public int Ddd { get; set; }
        [MinLength(8, ErrorMessage = "Digite um telefone válido e com apenas numeros"), MaxLength(9, ErrorMessage = "Digite um telefone válido e com apenas numeros")]
        public string Number { get; set; }

        public List<PhoneNumberDto> GetExample()
        {
            List<PhoneNumberDto> numbers = new();
            numbers.Add(new PhoneNumberDto()
            {
                Number = "998259340",
                Ddd = 31,
            });
            numbers.Add(new PhoneNumberDto()
            {
                Number = "32258081",
                Ddd = 34,
            });
            return numbers;
        }
    }
}
