using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class RoleRepository(DataContext context) : BaseRepository<RoleModel>(context), IRoleRepository
    {
        public new static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleModel>(entity =>
            {
                entity.ToTable("roles");

                // Mapeamento das propriedades
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created_at).IsRequired();
                entity.Property(e => e.Updated_at);
                entity.Property(e => e.Deleted_at);
                entity.Property(e => e.Deleted);
                entity.Property(e => e.Created_id).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.AuthorizedPaths);
            });

        }
    }
}
