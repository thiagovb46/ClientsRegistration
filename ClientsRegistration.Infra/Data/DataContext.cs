using ClientsRegistration.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace ClientsRegistration.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

    }
}
