using basic_api.Application.Base;
using basic_api.Application.Base.UseCase;
using basic_api.Application.Publisher.UseCases;
using basic_api.Domain.Publisher.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Publisher.Facade
{
    public class PublisherFacade(
        PublisherGetUseCase getUseCase, 
        PublisherDeleteUseCase deleteUseCase, 
        PublisherInsertUseCase insertUseCase, 
        PublisherUpdateUseCase updateUseCase
        ) : Facade<PublisherModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IPublisherFacade
    {
    }
}
