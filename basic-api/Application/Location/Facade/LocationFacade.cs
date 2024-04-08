using basic_api.Application.Base;
using basic_api.Application.Base.UseCase;
using basic_api.Domain.Location.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Location.Facade
{
    public class LocationFacade(
        GetUseCase<LocationModel> getUseCase, 
        DeleteUseCase<LocationModel> deleteUseCase, 
        InsertUseCase<LocationModel> insertUseCase, 
        UpdateUseCase<LocationModel> updateUseCase
        ) : Facade<LocationModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), ILocationFacade
    {
    }
}
