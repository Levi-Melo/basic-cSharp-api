using basic_api.Application.Base;
using basic_api.Domain.Location.UseCases;
using basic_api.Domain.Location.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Location.Facade
{
    public class LocationFacade(
        ILocationGetUseCase getUseCase, 
        ILocationDeleteUseCase deleteUseCase, 
        ILocationInsertUseCase insertUseCase, 
        ILocationUpdateUseCase updateUseCase
        ) : Facade<LocationModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), ILocationFacade
    {
    }
}
