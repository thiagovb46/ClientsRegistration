using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsRegistration.Application.Dto
{
    public class AddressDto
    {
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
    }
}
