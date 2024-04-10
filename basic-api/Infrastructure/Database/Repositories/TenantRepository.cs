using basic_api.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using basic_api.Infrastructure.Database.Context;
using System.Reflection;
using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Repositories
{
    public abstract class TenantenantRepository(DataContext context) : ITenantRepository
    {

        protected DbSet<ITenant> _dbSet = context.Set<ITenant>();


        private DataContext _context = context;

        public DbContext GetContext()
        {
            return _context;
        }

        public IEnumerable<ITenant> Get(IEnumerable<ITenant> input)
        {
            return
               [.. Get(true).Where(p => ContainsProperties(p, input))];
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

        public void Delete(IEnumerable<ITenant> input)
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

        private static bool ContainsProperties(ITenant instance, ITenant validationItem)
        {
            var validationTenantype = validationItem.GetType();

            {
                PropertyInfo[] validationProperties = validationTenantype.GetProperties();

                foreach (PropertyInfo property in validationProperties)
                {
                    var instanceValue = property.GetValue(instance);
                    var validationValue = property.GetValue(validationItem);

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
    }
}
