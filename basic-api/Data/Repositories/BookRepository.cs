using basic_api.Infrastructure.Database.Models;

namespace basic_api.Data.Repositories
{
    public interface IBookRepository : IBaseRepository<BookModel, BookModel>
    {
    }
}
