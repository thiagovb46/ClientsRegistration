using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsRegistration.Application.Dto
{
    public class AddressDto
    {
        #region Properties
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
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
                Neighborhood = "Santa Monica",
                State = "MG",
                Complement = "apto 405",
                City = "Uberlândia",
            };
        }
        #endregion
    }
}
