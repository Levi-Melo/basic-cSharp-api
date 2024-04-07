using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Book.UseCases
{
    public class BookInsertUseCase(BaseRepository<BookModel, BookModel> repo) : InsertUseCase<BookModel, BookModel>(repo)
    {
    }
}
