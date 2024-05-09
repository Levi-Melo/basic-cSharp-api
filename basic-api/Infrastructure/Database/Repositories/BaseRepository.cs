using basic_api.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage;

namespace basic_api.Infrastructure.Database.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {

        protected DbSet<T> _dbSet;
        private DataContext _context;
        private IDbContextTransaction _transaction;

        public BaseRepository(DataContext context){
            _dbSet = context.Set<T>();
            _context = context;
        }

        public DbContext GetContext()
        {
            return _context;
        }

        public IEnumerable<T> Get(GetManyParams<T> input)
        {
            var query = Get(true);
            if(input.Where != null){
                query = query.Where(p => BaseRepository<T>.ContainsProperties(p, input.Where));
            }

            if (input.Where != null)
            {
                query = query.Where(p => BaseRepository<T>.ContainsProperties(p, input.Where));
            }
            if (input.NotPage == null)
            {
                query = query.Skip((int)((input.Page - 1) * input.Size)).Take((int)input.Size);
            }
            return query.ToList();
        }

        public T Get(T input)
        {
            return 
                Get(true)
                .Where(p => BaseRepository<T>.ContainsProperties(p, input))
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

        public IEnumerable<T> Update(IEnumerable<T> input)

        {
            _context.Set<T>().UpdateRange(input);

            return input;
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);

            return entity;
        }

        public void Delete(T input)
        {
            var entity = Get(input);
            Remove(entity);
        }

        public void Delete(IEnumerable<T> input)
        {
            var param = new GetManyParams<T>()
            {
                Where = input,
                NotPage = true
            };
            var entities = Get(param);
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

        private void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        private void Remove(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
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
                    if (instanceValue is not null and object)
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

        private static bool ContainsProperties(T instance, IEnumerable<T> validationItems)
        {
            var results =
                validationItems
                .Select(item => ContainsProperties(instance, item))
                .ToArray();

            return results.Contains(true);
        }

        private IQueryable<T> Get(bool track = true)
        {
            if (!track)
            {
                return _dbSet.AsNoTracking();
            }

            return _dbSet;

        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
