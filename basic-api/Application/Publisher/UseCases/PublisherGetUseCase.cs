using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Publisher.UseCases;
using basic_api.Data.Repositories;

namespace basic_api.Application.Publisher.UseCases
{
    public class PublisherGetUseCase(IPublisherRepository repo) : GetUseCase<PublisherModel>(repo), IPublisherGetUseCase
    {
    }
}
