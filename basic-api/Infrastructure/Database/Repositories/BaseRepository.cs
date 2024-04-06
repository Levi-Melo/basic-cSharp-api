using basic_api.Data.Repositories;
using basic_api.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using System.Reflection;

namespace basic_api.Infrastructure.Database.Repositories
{
    public abstract class BaseRepository<T, G>(DataContext context) : IBaseRepository<T, G>
        where T : BaseEntity
        where G : T
    {

        protected DbSet<T> _dbSet = context.Set<T>();


        private DataContext _context = context;

        public DbContext GetContext()
        {
            return _context;
        }

        public IEnumerable<T> Get(IEnumerable<G> input)
        {
            return
               Get(true)
               .Where(p => ContainsProperties(p, input))
               .ToList();
        }

        public T Get(G input)
        {
            return 
                Get(true)
                .Where(p => ContainsProperties(p, input))
                .Single();
        }

        public T Insert(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }


        public IEnumerable<T> Insert(IEnumerable<T> input)
        {
            _context.Set<T>().AddRange(input);

            return input;
        }

        public IEnumerable<T> Update(IEnumerable<G> input)

        {
            _context.Set<T>().UpdateRange(input);

            return input;
        }
        public T Update(G entity)
        {
            _context.Set<T>().Update(entity);

            return entity;
        }

        public void Delete(G input)
        {
            var entity = Get(input);
            Delete(entity);
        }

        public void Delete(IEnumerable<G> input)
        {
            var entities = Get(input);
            Delete(entities);
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

        private bool ContainsProperties(T instance, G validationItem)
        {
            var validationType = validationItem.GetType();

            {
                PropertyInfo[] validationProperties = validationType.GetProperties();

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

        private bool ContainsProperties(T instance, IEnumerable<G> validationItems)
        {
            var results = 
                validationItems
                .Select(item => ContainsProperties(instance, item))
                .ToArray();

            return results.Contains(true);
        }

        private void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        private void Delete(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
        private IQueryable<T> Get(bool track = true)
        {
            if (!track)
            {
                return _dbSet.AsNoTracking();
            }

            return _dbSet;

        }
    }
}
