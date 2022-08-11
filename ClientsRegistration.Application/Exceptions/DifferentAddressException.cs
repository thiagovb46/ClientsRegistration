namespace ClientsRegistration.Application.Exceptions
{
    public class DifferentAddressException : Exception
    {
        public DifferentAddressException(string field) : base($"Campo{ field }do endereço não condiz com os correios") { }
    }
}
