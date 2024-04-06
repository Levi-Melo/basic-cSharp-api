using basic_api.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public override int SaveChanges()
        {
            var updateData = new UpdateData
            {
                timestamp = DateTime.Now
            };

            var entries = ChangeTracker
               .Entries()
               .Where(e =>
               {
                   return e.Entity is IAudit &&
                    (
                        e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted
                    );
               });

            foreach (var entityEntry in entries)
            {
                var audit = (IAudit)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    if (audit != null)
                    {
                        audit.created_id = new Guid();
                        audit.created_at = updateData.timestamp;
                    }
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    if (audit != null)
                    {
                        audit.updated_at = updateData.timestamp;
                    }

                    var deletable = (ISoftDeletable)entityEntry.Entity;

                    if (deletable != null && deletable.deleted)
                    {
                        SoftDelete(entityEntry, updateData);
                    }
                }
                else if (entityEntry.State == EntityState.Deleted)
                {
                    SoftDelete(entityEntry, updateData);
                }
            }

            return base.SaveChanges();
        }

        private void SoftDelete(
            EntityEntry entityEntry,
            UpdateData updateData)
        {
            var deletable = (ISoftDeletable)entityEntry.Entity;

            if (deletable != null)
            {
                entityEntry.State = EntityState.Unchanged;
                deletable.deleted = true;

                SoftCascade(entityEntry, updateData);
            }

            var audit = (IAudit)entityEntry.Entity;

            if (audit != null)
            {
                audit.deleted_id = new Guid();
                audit.deleted_at = updateData.timestamp;
            }
        }

        private void SoftCascade(
            EntityEntry entityEntry,
            UpdateData updateData)
        {
           throw new NotImplementedException();
        }

        private struct UpdateData
        {
            public DateTime timestamp;
        }
    }
}
