using basic_api.Application.Base.UseCase;
using basic_api.Domain.Genre.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Genre.UseCases
{
    public class GenreDeleteUseCase(BaseRepository<GenreModel> repo) : DeleteUseCase<GenreModel>(repo), IGenreDeleteUseCase
    {
    }
}
