using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Domain.Book.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Book.UseCases
{
    public class BookDeleteUseCase(IBookRepository repo) : DeleteUseCase<BookModel>(repo), IBookDeleteUseCase
    {
    }
}
