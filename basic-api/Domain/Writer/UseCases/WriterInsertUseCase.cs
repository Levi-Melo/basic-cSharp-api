using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Writer.UseCases
{
    public interface IWriterInsertUseCase : IInsertUseCase<WriterModel>
    {
    }
}
