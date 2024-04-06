using Microsoft.EntityFrameworkCore;

namespace basic_api.Infrastructure.Database.Context
{
    public class DataContext : Context
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
