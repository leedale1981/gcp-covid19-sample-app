using COV19.Services.Domain;
using Microsoft.EntityFrameworkCore;

namespace COV19.Services.Data
{
    public class AuthContext : DbContext
    {
        private readonly string _connectionString;

        public AuthContext()
        {
            // Use this connection string to support migrations.
            this._connectionString = "Host=localhost;Database=auth-postgresdb;Username=postgres;Password=M1llwall01"; // Local
        }

        public AuthContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public virtual DbSet<ClientRegistration> ClientRegistrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(this._connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientRegistration>()
                .HasKey(d => d.ClientId);
            modelBuilder.Entity<ClientRegistration>()
                .Property(d => d.ClientSecret)
                .IsRequired(); 
            
        }
    }
}