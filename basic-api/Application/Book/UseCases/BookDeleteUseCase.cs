using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Book.UseCases
{
    public class BookDeleteUseCase(BaseRepository<BookModel> repo) : DeleteUseCase<BookModel>(repo)
    {
    }
}
