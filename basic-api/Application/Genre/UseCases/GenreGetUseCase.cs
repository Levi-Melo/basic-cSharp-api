using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Genre.UseCases;

namespace basic_api.Application.Genre.UseCases
{
    public class GenreGetUseCase(BaseRepository<GenreModel> repo) : GetUseCase<GenreModel>(repo), IGenreGetUseCase
    {
    }
}
