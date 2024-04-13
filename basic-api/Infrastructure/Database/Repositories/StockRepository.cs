using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class StockRepository(DataContext context) : BaseRepository<StockModel>(context), IStockRepository
    {
        public new static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockModel>(entity =>
            {
                entity.ToTable("stocks");

                // Mapeamento das propriedades
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created_at).IsRequired();
                entity.Property(e => e.Updated_at);
                entity.Property(e => e.Deleted_at);
                entity.Property(e => e.Deleted);
                entity.Property(e => e.Created_id).IsRequired();
                entity.Property(e => e.HaveFile).IsRequired();
                entity.Property(e => e.Reserved).IsRequired();

                entity.HasOne(e => e.Item).WithMany().HasForeignKey(e => e.Item.Id);
                entity.HasOne(e => e.Location).WithMany().HasForeignKey(e => e.Location.Id);
                entity.HasMany(e => e.Orders).WithMany(e => e.StockBooks).UsingEntity(j => j.ToTable("OrderStockBooks"));
                entity.HasOne(e => e.Tenant).WithMany().HasForeignKey(j => j.Tenant.Id);
            });

        }
    }
}
