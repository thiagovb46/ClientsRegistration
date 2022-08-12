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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.Cpf).IsUnique();
            });
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.Cnpj).IsUnique();
            });
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}
