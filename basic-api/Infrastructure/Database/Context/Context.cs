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
                timestamp = DateTime.Now,
                operationId = new Guid()
            };

            var entries = ChangeTracker
               .Entries()
               .Where(e =>
               {
                   return e.Entity is IBaseEntity &&
                    (
                        e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted
                    );
               });

            foreach (var entityEntry in entries)
            {
                throw new NotImplementedException("ADD LOG MANAGEMENT");
                var audit = (IBaseEntity)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    if (audit != null)
                    {
                        audit.created_id = updateData.operationId;
                        audit.created_at = updateData.timestamp;
                        audit.Id = updateData.operationId;
                    }
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    if (audit != null)
                    {
                        if (audit.updated_id != null)
                        {
                            audit.updated_id.Add(updateData.operationId);
                        }
                        else
                        {
                            audit.updated_id = [updateData.operationId];

                        }

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

            var audit = (IBaseEntity)entityEntry.Entity;

            if (audit != null)
            {
                if (audit.updated_id != null)
                {
                    audit.updated_id.Add(updateData.operationId);

                }
                else
                {
                    audit.updated_id = [updateData.operationId];

                }
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
            public Guid operationId;
        }
    }
}
