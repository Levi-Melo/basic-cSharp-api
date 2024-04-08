using basic_api.Application.Base.UseCase;
using basic_api.Domain.Writer.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Writer.UseCases
{
    public class WriterDeleteUseCase(BaseRepository<WriterModel> repo) : DeleteUseCase<WriterModel>(repo), IWriterDeleteUseCase
    {
    }
}
