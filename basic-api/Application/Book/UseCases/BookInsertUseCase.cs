using basic_api.Application.Base.UseCase;
using basic_api.Domain.Book.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Book.UseCases
{
    public class BookInsertUseCase(BaseRepository<BookModel> repo) : InsertUseCase<BookModel>(repo), IBookInsertUseCase
    {
    }
}
