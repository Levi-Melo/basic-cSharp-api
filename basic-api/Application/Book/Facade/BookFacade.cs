using basic_api.Application.Base;
using basic_api.Application.Base.UseCase;
using basic_api.Domain.Book.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Book.Facade
{
    public class BookFacade(
        GetUseCase<BookModel> getUseCase, 
        DeleteUseCase<BookModel> deleteUseCase, 
        InsertUseCase<BookModel> insertUseCase, 
        UpdateUseCase<BookModel> updateUseCase
        ) : Facade<BookModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IBookFacade
    {
    }
}
