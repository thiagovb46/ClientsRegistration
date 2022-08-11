namespace ClientsRegistration.Infra
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException() : base("Não existe cliente com Id informado")
        {
        }

    }
}
