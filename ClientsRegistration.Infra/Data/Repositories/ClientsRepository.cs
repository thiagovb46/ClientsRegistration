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
            _context.Remove<Client>(client);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAll()
        {
            var clients = await _context.Clients
                .Include(c => c.Address).Include(c => c.PhoneNumbers).ToListAsync();
            return clients;
        }

        public async Task<Client> GetOne(int id)
        {
            var client = await _context.Clients.Include(c => c.Address)
                .Include(c => c.PhoneNumbers)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (client == null)
                throw new ClientNotFoundException();
            return client;
        }
        public async Task<bool> ClientExists(Client client)
        {
            var cpfExists = client.Cpf != null
                ? await _context.Clients.AnyAsync(c => c.Cpf == client.Cpf)
                : false;
            var cnpjExists = client.Cnpj != null
                ? await _context.Clients.AnyAsync(c => c.Cnpj == client.Cnpj)
                : false;
            var emailExists = client.Email == null
                ? await _context.Clients.AnyAsync(c => c.Cnpj == client.Cnpj)
                : false;

            return cpfExists || cnpjExists || emailExists;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
