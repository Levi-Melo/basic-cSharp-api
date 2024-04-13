using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Domain.Publisher.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Publisher.UseCases
{
    public class PublisherInsertUseCase(IPublisherRepository repo) : InsertUseCase<PublisherModel>(repo), IPublisherInsertUseCase
    {
    }
}
