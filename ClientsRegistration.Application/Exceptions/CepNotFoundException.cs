namespace ClientsRegistration.Application.Exceptions
{
    public class CepNotFoundException : Exception
    {
        public CepNotFoundException() : base("O Cep  informado é invalido") { }
    }
}
