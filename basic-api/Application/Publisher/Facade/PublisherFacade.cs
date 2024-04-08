using basic_api.Application.Base;
using basic_api.Application.Base.UseCase;
using basic_api.Domain.Publisher.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Publisher.Facade
{
    public class PublisherFacade(
        GetUseCase<PublisherModel> getUseCase, 
        DeleteUseCase<PublisherModel> deleteUseCase, 
        InsertUseCase<PublisherModel> insertUseCase, 
        UpdateUseCase<PublisherModel> updateUseCase
        ) : Facade<PublisherModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IPublisherFacade
    {
    }
}
