using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Publisher.UseCases;

namespace basic_api.Application.Publisher.UseCases
{
    public class PublisherGetUseCase(BaseRepository<PublisherModel> repo) : GetUseCase<PublisherModel>(repo), IPublisherGetUseCase
    {
    }
}
