using basic_api.Application.Base;
using basic_api.Domain.Writer.UseCases;
using basic_api.Domain.Writer.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Writer.Facade
{
    public class WriterFacade(
        IWriterGetUseCase getUseCase,
        IWriterDeleteUseCase deleteUseCase,
        IWriterInsertUseCase insertUseCase,
        IWriterUpdateUseCase updateUseCase
        ) : Facade<WriterModel>(
            getUseCase,
            deleteUseCase,
            insertUseCase,
            updateUseCase), IWriterFacade
    {
    }
}
