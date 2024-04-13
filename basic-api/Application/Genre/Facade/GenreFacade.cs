using basic_api.Application.Base;
using basic_api.Domain.Genre.UseCases;
using basic_api.Domain.Genre.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Genre.Facade
{
    public class GenreFacade(
        IGenreGetUseCase getUseCase, 
        IGenreDeleteUseCase deleteUseCase, 
        IGenreInsertUseCase insertUseCase, 
        IGenreUpdateUseCase updateUseCase
        ) : Facade<GenreModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IGenreFacade
    {
    }
}
