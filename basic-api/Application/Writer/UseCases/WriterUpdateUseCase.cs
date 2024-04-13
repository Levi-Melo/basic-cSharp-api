using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Domain.Writer.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Writer.UseCases
{
    public class WriterUpdateUseCase(IWriterRepository repo) : UpdateUseCase<WriterModel>(repo), IWriterUpdateUseCase
    {
    }
}
