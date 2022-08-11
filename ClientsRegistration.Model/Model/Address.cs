namespace ClientsRegistration.Model.Model
{
    public class Address
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public Client Client { get; set; }
    }
}
