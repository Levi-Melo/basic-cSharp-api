using basic_api.Application.Base;
using basic_api.Application.Location.UseCases;
using basic_api.Domain.Location.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Location.Facade
{
    public class LocationFacade(
        LocationGetUseCase getUseCase, 
        LocationDeleteUseCase deleteUseCase, 
        LocationInsertUseCase insertUseCase, 
        LocationUpdateUseCase updateUseCase
        ) : Facade<LocationModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), ILocationFacade
    {
    }
}
