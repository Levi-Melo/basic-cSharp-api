using basic_api.Application.Base;
using basic_api.Application.Base.UseCase;
using basic_api.Domain.Genre.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Genre.Facade
{
    public class GenreFacade(
        GetUseCase<GenreModel> getUseCase, 
        DeleteUseCase<GenreModel> deleteUseCase, 
        InsertUseCase<GenreModel> insertUseCase, 
        UpdateUseCase<GenreModel> updateUseCase
        ) : Facade<GenreModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IGenreFacade
    {
    }
}
