using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using basic_api.Data.Entities.Base;

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
                        audit.Created_id = updateData.operationId;
                        audit.Created_at = updateData.timestamp;
                        audit.Id = updateData.operationId;
                    }
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    var before = (IBaseEntity)entityEntry.OriginalValues;
                    if (audit != null)
                    {
                        if (before.Updated_id != null)
                        {
                            before.Updated_id.Add(updateData.operationId);
                            audit.Updated_id = before.Updated_id;
                        }
                        else
                        {
                            audit.Updated_id = [updateData.operationId];
                        }

                        audit.Updated_at = updateData.timestamp;
                    }

                    var deletable = (ISoftDeletable)entityEntry.Entity;

                    if (deletable != null && deletable.Deleted)
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
            var before = (IBaseEntity)entityEntry.OriginalValues;

            if (deletable != null)
            {
                entityEntry.State = EntityState.Unchanged;
                deletable.Deleted = true;

                SoftCascade(entityEntry, updateData);
            }

            var audit = (IBaseEntity)entityEntry.Entity;

            if (audit != null)
            {
                if (before.Deleted_id != null)
                {
                    before.Deleted_id.Add(updateData.operationId);
                    audit.Deleted_id = before.Deleted_id;
                }
                else
                {
                    audit.Deleted_id = [updateData.operationId];
                }
                audit.Deleted_at = updateData.timestamp;
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
