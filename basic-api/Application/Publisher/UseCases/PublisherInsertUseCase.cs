using basic_api.Application.Base.UseCase;
using basic_api.Domain.Publisher.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Publisher.UseCases
{
    public class PublisherInsertUseCase(PublisherRepository repo) : InsertUseCase<PublisherModel>(repo), IPublisherInsertUseCase
    {
    }
}
