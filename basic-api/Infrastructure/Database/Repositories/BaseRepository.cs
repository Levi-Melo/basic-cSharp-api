using basic_api.Data.Repositories;
using basic_api.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class BaseRepository<T, G> : IBaseRepository<T, G>
        where T : BaseEntity
        where G : T
    {

        protected DbSet<T> _dbSet;


        private DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }
        public DbContext GetContext()
        {
            return _context;
        }
        public T Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(IEnumerable<G> input)
        {
            throw new NotImplementedException();
        }

        public T FindOne(T input)
        {
            throw new NotImplementedException();
        }

        public T Insert(Guid id, G input)
        {
            throw new NotImplementedException();
        }

        public T Update(T input)
        {
            throw new NotImplementedException();
        }
    }
}
