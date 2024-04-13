using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class GenreRepository(DataContext context) : BaseRepository<GenreModel>(context), IGenreRepository
    {
        new public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreModel>(entity =>
            {
                entity.ToTable("genres");

                // Mapeamento das propriedades
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created_at).IsRequired();
                entity.Property(e => e.Updated_at);
                entity.Property(e => e.Deleted_at);
                entity.Property(e => e.Deleted);
                entity.Property(e => e.Created_id).IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100); // Exemplo: string com no máximo 100 caracteres
                entity.Property(e => e.Description).HasMaxLength(500); // Exemplo: string com no máximo 500 caracteres

                // Mapeamento das relações
                entity.HasOne(e => e.Tenant).WithMany().HasForeignKey(j => j.Tenant.Id);
                entity.HasMany(e => e.Books).WithMany(e => e.Genres).UsingEntity(j => j.ToTable("GenresBooks"));
                entity.HasMany(e => e.Writers).WithMany(e => e.Genres).UsingEntity(j => j.ToTable("GenresWriters"));
            });
        }
    }
}
