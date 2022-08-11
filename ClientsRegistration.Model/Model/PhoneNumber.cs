using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsRegistration.Model.Model
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Ddd { get; set; }
        public string Number { get; set; }
        public Client Client { get; set; }
    }
}
