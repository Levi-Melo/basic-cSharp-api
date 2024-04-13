using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class AccountRepository(DataContext context) : BaseRepository<AccountModel>(context), IAccountRepository
    {
        new public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>(entity =>
            {
                entity.ToTable("accounts");
                // Mapeamento das propriedades
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created_at).IsRequired();
                entity.Property(e => e.Updated_at);
                entity.Property(e => e.Deleted_at);
                entity.Property(e => e.Deleted);
                entity.Property(e => e.Created_id).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Document).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Phone).IsRequired();

                // Mapeamento das relações
                entity.HasOne(e => e.Tenant).WithMany().HasForeignKey(j => j.Tenant.Id);
                entity.HasOne(e => e.Role).WithMany().HasForeignKey(e => e.Role.Id);
                entity.HasMany(e => e.Orders).WithOne(e => e.OrderAuthor).HasForeignKey(e => e.OrderAuthor.Id);
            });
        }
    }
}