using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Domain.Genre.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Genre.UseCases
{
    public class GenreInsertUseCase(IGenreRepository repo) : InsertUseCase<GenreModel>(repo), IGenreInsertUseCase
    {
    }
}
