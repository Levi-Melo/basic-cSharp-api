using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class PublisherRepository(DataContext context) : BaseRepository<PublisherModel>(context), IPublisherRepository
    {
        public new static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublisherModel>(entity =>
            {
                entity.ToTable("publisher");

                // Mapeamento das propriedades
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created_at).IsRequired();
                entity.Property(e => e.Updated_at);
                entity.Property(e => e.Deleted_at);
                entity.Property(e => e.Deleted);
                entity.Property(e => e.Created_id).IsRequired();
                entity.Property(e => e.Name).IsRequired(); 
                entity.Property(e => e.Document).IsRequired(); 
                entity.Property(e => e.Address).IsRequired();

                entity.HasMany(e => e.Books).WithOne(book => book.Publisher).HasForeignKey(book => book.Publisher.Id);
                entity.HasOne(e => e.Tenant).WithMany().HasForeignKey(j => j.Tenant.Id);
            });

        }
    }
}
