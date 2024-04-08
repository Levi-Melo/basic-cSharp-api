using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Location.UseCases;

namespace basic_api.Application.Location.UseCases
{
    public class LocationGetUseCase(BaseRepository<LocationModel> repo) : GetUseCase<LocationModel>(repo), ILocationGetUseCase
    {
    }
}
