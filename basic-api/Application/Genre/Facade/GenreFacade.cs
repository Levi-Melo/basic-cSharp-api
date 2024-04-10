using basic_api.Application.Base;
using basic_api.Application.Genre.UseCases;
using basic_api.Domain.Genre.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Genre.Facade
{
    public class GenreFacade(
        GenreGetUseCase getUseCase, 
        GenreDeleteUseCase deleteUseCase, 
        GenreInsertUseCase insertUseCase, 
        GenreUpdateUseCase updateUseCase
        ) : Facade<GenreModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IGenreFacade
    {
    }
}
