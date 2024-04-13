using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Domain.Location.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Location.UseCases
{
    public class LocationDeleteUseCase(ILocationRepository repo) : DeleteUseCase<LocationModel>(repo), ILocationDeleteUseCase
    {
    }
}
