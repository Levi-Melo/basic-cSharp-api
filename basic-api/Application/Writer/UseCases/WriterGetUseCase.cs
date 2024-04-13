using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Writer.UseCases;
using basic_api.Data.Repositories;

namespace basic_api.Application.Writer.UseCases
{
    public class WriterGetUseCase(IWriterRepository repo) : GetUseCase<WriterModel>(repo), IWriterGetUseCase
    {
    }
}
