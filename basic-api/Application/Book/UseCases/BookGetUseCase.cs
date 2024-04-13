using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Book.UseCases;
using basic_api.Data.Repositories;

namespace basic_api.Application.Book.UseCases
{
    public class BookGetUseCase(IBookRepository repo) : GetUseCase<BookModel>(repo), IBookGetUseCase
    {
    }
}
