using basic_api.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using basic_api.Infrastructure.Database.Context;
using System.Reflection;
using basic_api.Data.Entities;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class TenantRepository(DataContext context) : ITenantRepository
    {

        protected DbSet<ITenant> _dbSet = context.Set<ITenant>();


        private DataContext _context = context;

        public DbContext GetContext()
        {
            return _context;
        }

        public IEnumerable<ITenant> Get(GetManyParams<ITenant> input)
        {
            var query = Get(true);
            if (input.Where != null)
            {
                query = query.Where(p => ContainsProperties(p, input.Where));
            }

            if (input.Where != null)
            {
                query = query.Where(p => ContainsProperties(p, input.Where));
            }
            if (input.NotPage == null)
            {
                query = query.Skip((int)((input.Page - 1) * input.Size)).Take((int)input.Size);
            }
            return query.ToList();
        }

        public ITenant Get(ITenant input)
        {
            return 
                Get(true)
                .Where(p => ContainsProperties(p, input))
                .Single();
        }

        public ITenant Insert(ITenant entity)
        {
            _context.Set<ITenant>().Add(entity);

            return entity;
        }


        public IEnumerable<ITenant> Insert(IEnumerable<ITenant> input)
        {
            _context.Set<ITenant>().AddRange(input);

            return input;
        }

        public IEnumerable<ITenant> Update(IEnumerable<ITenant> input)

        {
            _context.Set<ITenant>().UpdateRange(input);

            return input;
        }
        public ITenant Update(ITenant entity)
        {
            _context.Set<ITenant>().Update(entity);

            return entity;
        }

        public void Delete(ITenant input)
        {
            var entity = Get(input);
            Remove(entity);
        }

        public void Delete(GetManyParams<ITenant> input)
        {
            var entities = Get(input);
            Remove(entities);
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        private static bool ContainsProperties(object instance, object validationItem)
        {
            var validationType = validationItem.GetType();

            {
                PropertyInfo[] validationProperties = validationType.GetProperties();

                foreach (PropertyInfo property in validationProperties)
                {
                    var instanceValue = property.GetValue(instance);

                    var validationValue = property.GetValue(validationItem);
                    if (instanceValue is object)
                    {
                        return ContainsProperties(instanceValue, validationProperties);
                    }

                    if (instanceValue == null && validationValue == null)
                        continue;

                    if (instanceValue == null || validationValue == null)
                        return false;

                    if (!instanceValue.Equals(validationValue))
                        return false;
                }
            }

            return true; // Se todas as propriedades forem iguais, retorna verdadeiro
        }

        private static bool ContainsProperties(ITenant instance, IEnumerable<ITenant> validationItems)
        {
            var results =
                validationItems
                .Select(item => ContainsProperties(instance, item))
                .ToArray();

            return results.Contains(true);
        }

        private void Remove(ITenant entity)
        {
            _dbSet.Remove(entity);
        }

        private void Remove(IEnumerable<ITenant> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        private IQueryable<ITenant> Get(bool track = true)
        {
            if (!track)
            {
                return _dbSet.AsNoTracking();
            }

            return _dbSet;

        }
        new public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantModel>(entity =>
            {
                entity.ToTable("tenants");
                // Mapeamento das propriedades
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created_at).IsRequired();
                entity.Property(e => e.Updated_at);
                entity.Property(e => e.Deleted_at);
                entity.Property(e => e.Deleted);
                entity.Property(e => e.Created_id).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Document).IsRequired();
                entity.Property(e => e.ValidUntil).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Phone).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();
            });

        }


    }
}
