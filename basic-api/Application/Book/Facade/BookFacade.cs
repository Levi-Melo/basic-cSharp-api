using basic_api.Domain.Book.UseCases;
using basic_api.Application.Base;
using basic_api.Domain.Book.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Book.Facade
{
    public class BookFacade(
        IBookGetUseCase bookGetUseCase,
        IBookDeleteUseCase bookDeleteUseCase,
        IBookInsertUseCase bookInsertUseCase,
        IBookUpdateUseCase bookUpdateUseCase
        ) : Facade<BookModel>(
            bookGetUseCase,
            bookDeleteUseCase,
            bookInsertUseCase,
            bookUpdateUseCase), IBookFacade
    {
    }
}
