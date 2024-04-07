using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Context;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Infrastructure.Database.Repositories
{
    public class GenreRepository(DataContext context) : BaseRepository<Genre, Genre>(context), IGenreRepository
    {
    }
}
