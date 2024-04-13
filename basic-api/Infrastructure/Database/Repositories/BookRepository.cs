using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class BookRepository(DataContext context) : BaseRepository<BookModel>(context), IBookRepository
    {
        new public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>(entity =>
            {
                entity.ToTable("books");
                // Mapeamento das propriedades
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created_at).IsRequired();
                entity.Property(e => e.Updated_at);
                entity.Property(e => e.Deleted_at);
                entity.Property(e => e.Deleted);
                entity.Property(e => e.Created_id).IsRequired();
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Synopsis).IsRequired();
                entity.Property(e => e.Pages).IsRequired();
                entity.Property(e => e.PublishedAt).IsRequired();
                entity.Property(e => e.Edition).IsRequired();
                entity.Property(e => e.Material);

                // Mapeamento das relações
                entity.HasOne(e => e.Tenant).WithMany().HasForeignKey(j => j.Tenant.Id);
                entity.HasOne(e => e.Ilustrator).WithMany(e => e.Books).HasForeignKey(e => e.Ilustrator.Id);
                entity.HasOne(e => e.Publisher).WithMany(e => e.Books).HasForeignKey(e => e.Publisher.Id);
                entity.HasOne(e => e.Translator).WithMany(e => e.Books).HasForeignKey(e => e.Translator.Id);
                entity.HasMany(e => e.Author).WithMany(e => e.Books).UsingEntity(j => j.ToTable("WritersBooks"));
                entity.HasMany(e => e.Reviewer).WithMany(e => e.Books).UsingEntity(j => j.ToTable("WritersBooks"));
                entity.HasMany(e => e.Genres).WithMany(e => e.Books).UsingEntity(j => j.ToTable("GenresBooks"));

                entity.HasMany(e => e.Orders).WithMany(e => e.Books).UsingEntity(j => j.ToTable("OrderBooks"));
                entity.HasMany(e => e.Orders).WithMany(e => e.InvalidBooks).UsingEntity(j => j.ToTable("OrderInvalidBooks"));
            });

        }
    }
}
