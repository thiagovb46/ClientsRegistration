using ClientsRegistration.Model.Model;

namespace ClientsRegistration.Model.IRepositories
{
    public interface IClientsRepository
    {
        Task<Client> Create(Client client);
        Task<List<Client>> GetAll();
        Task<Client> GetOne(int id);
        Task SaveChangesAsync();
        Task Delete(Client client);
        Task<bool> ClientExists(Client client);
    }
}
