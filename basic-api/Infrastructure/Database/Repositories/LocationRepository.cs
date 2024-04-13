using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class LocationRepository(DataContext context) : BaseRepository<LocationModel>(context), ILocationRepository
    {
        public new static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationModel>(entity =>
            {
                entity.ToTable("locations");

                // Mapeamento das propriedades
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created_at).IsRequired();
                entity.Property(e => e.Updated_at);
                entity.Property(e => e.Deleted_at);
                entity.Property(e => e.Deleted);
                entity.Property(e => e.Created_id).IsRequired();
                entity.Property(e => e.Name).IsRequired(); // Exemplo: string com no máximo 100 caracteres

                // Mapeamento da propriedade Metadata como JSON no banco de dados
                entity.Property(e => e).HasColumnType("json");

                // Mapeamento das relações
                entity.HasOne(e => e.Tenant).WithMany().HasForeignKey(j => j.Tenant.Id);
                entity.HasMany(e => e.Books).WithOne(book => book.Location).HasForeignKey(book => book.Location);
            });

        }
    }
}
