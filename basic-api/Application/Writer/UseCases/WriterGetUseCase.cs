using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Writer.UseCases;

namespace basic_api.Application.Writer.UseCases
{
    public class WriterGetUseCase(WriterRepository repo) : GetUseCase<WriterModel>(repo), IWriterGetUseCase
    {
    }
}
