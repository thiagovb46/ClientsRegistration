using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsRegistration.Application.Dto
{
    public class PhoneNumberDto
    {
        public int Ddd { get; set; }
        public string Number { get; set; }

        public List<PhoneNumberDto> GetExample()
        {
            List<PhoneNumberDto> numbers = new();
            numbers.Add(new PhoneNumberDto()
            {
                Number = "998259340",
                Ddd = Ddd,
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
