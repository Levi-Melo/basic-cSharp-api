using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class OrderRepository(DataContext context) : BaseRepository<OrderModel>(context), IOrderRepository
    {
        public new static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderModel>(entity =>
            {
                entity.ToTable("orders");

                // Mapeamento das propriedades
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created_at).IsRequired();
                entity.Property(e => e.Updated_at);
                entity.Property(e => e.Deleted_at);
                entity.Property(e => e.Deleted);
                entity.Property(e => e.Created_id).IsRequired();
                entity.Property(e => e.Accept);
                entity.Property(e => e.DevolveAt);
                entity.Property(e => e.Devolved);

                entity.HasMany(e => e.Books).WithMany(book => book.Orders).UsingEntity(j => j.ToTable("OrderBooks"));
                entity.HasMany(e => e.InvalidBooks).WithMany(book => book.Orders).UsingEntity(j => j.ToTable("OrderInvalidBooks"));
                entity.HasMany(e => e.StockBooks).WithMany(stock => stock.Orders).UsingEntity(j => j.ToTable("OrderStockBooks"));
                entity.HasOne(e => e.Tenant).WithMany().HasForeignKey(j => j.Tenant.Id);
                entity.HasOne(e => e.OrderAuthor).WithMany().HasForeignKey(e => e.OrderAuthor.Id);
            });

        }
    }
}
