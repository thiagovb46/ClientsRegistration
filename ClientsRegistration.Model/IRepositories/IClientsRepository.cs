using ClientsRegistration.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsRegistration.Model.IRepositories
{
    public interface IClientsRepository
    {
        Task<Client> Create(Client client);
        Task<List<Client>> GetAll();
        Task<Client> GetOne(int id);
        Task SaveChangesAsync();
        Task Delete(Client client);
    }
}
