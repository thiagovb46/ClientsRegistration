using ClientsRegistration.Model.IRepositories;
using ClientsRegistration.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace ClientsRegistration.Infra.Data.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly DataContext _context;

        public ClientsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Client> Create(Client client)
        {
            var newClient = await _context.Clients.AddAsync(client);
            await SaveChangesAsync();
            return newClient.Entity;
        }

        public async Task Delete(Client client)
        {
            _context.Clients.Remove(client);
            await SaveChangesAsync();
        }

        public async Task<List<Client>> GetAll()
        {
            var clients = await _context.Clients.ToListAsync();
            return clients;
        }

        public async Task<Client> GetOne(int id)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (client.Equals(default))
                throw new ClientNotFoundException();
            return client;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
