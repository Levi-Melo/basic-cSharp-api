using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Location.UseCases
{
    public interface ILocationInsertUseCase : IInsertUseCase<LocationModel>
    {
    }
}
