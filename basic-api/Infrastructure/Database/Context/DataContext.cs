using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : Context(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AccountRepository.OnModelCreating(modelBuilder);
            BookRepository.OnModelCreating(modelBuilder);
            GenreRepository.OnModelCreating(modelBuilder);
            LocationRepository.OnModelCreating(modelBuilder);
            OrderRepository.OnModelCreating(modelBuilder);
            PublisherRepository.OnModelCreating(modelBuilder);
            RoleRepository.OnModelCreating(modelBuilder);
            StockRepository.OnModelCreating(modelBuilder);
            TenantRepository.OnModelCreating(modelBuilder);
            WriterRepository.OnModelCreating(modelBuilder);
        }
    }
}
