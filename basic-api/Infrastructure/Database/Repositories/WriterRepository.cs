using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class WriterRepository(DataContext context) : BaseRepository<WriterModel>(context), IWriterRepository
    {
        public new static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WriterModel>(entity =>
            {
                entity.ToTable("writers");

                // Mapeamento das propriedades
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created_at).IsRequired();
                entity.Property(e => e.Updated_at);
                entity.Property(e => e.Deleted_at);
                entity.Property(e => e.Deleted);
                entity.Property(e => e.Created_id).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.IsTranslator).IsRequired();
                entity.Property(e => e.Nation).IsRequired();
                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(e => e.Tenant).WithMany().HasForeignKey(j => j.Tenant.Id);
                entity.HasMany(e => e.Books).WithMany(e => e.Author).UsingEntity(j => j.ToTable("WritersBooks"));
                entity.HasMany(e => e.Books).WithMany(e => e.Reviewer).UsingEntity(j => j.ToTable("WritersBooks"));
                entity.HasMany(e => e.Genres).WithMany(e => e.Writers).UsingEntity(j => j.ToTable("GenresWriters"));
                entity.HasOne(e => e.Tenant).WithMany().HasForeignKey(j => j.Tenant.Id);
            });

        }
    }
}
