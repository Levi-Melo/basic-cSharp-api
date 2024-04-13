using basic_api.Application.Base;
using basic_api.Domain.Publisher.UseCases;
using basic_api.Domain.Publisher.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Publisher.Facade
{
    public class PublisherFacade(
        IPublisherGetUseCase getUseCase, 
        IPublisherDeleteUseCase deleteUseCase, 
        IPublisherInsertUseCase insertUseCase, 
        IPublisherUpdateUseCase updateUseCase
        ) : Facade<PublisherModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IPublisherFacade
    {
    }
}
