using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Book.UseCases;

namespace basic_api.Application.Book.UseCases
{
    public class BookGetUseCase(BaseRepository<BookModel> repo) : GetUseCase<BookModel>(repo), IBookGetUseCase
    {
    }
}
